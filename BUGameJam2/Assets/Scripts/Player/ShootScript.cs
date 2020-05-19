using Assets.Scripts.DataTypes;
using Assets.Scripts.Flyers;
using Assets.Scripts.Input;
using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts.Player
{
    public class ShootScript : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField]
        private Transform indicator = null;

        [SerializeField]
        private Transform body = null;

        [SerializeField]
        private Renderer meshRenderer = null;

        [SerializeField]
        private Transform playerCamera = null;

        [SerializeField]
        private Vector3 indicatorOffset = Vector3.zero;

        [SerializeField]
        private GameObject flyerPrefab = null;

        [SerializeField]
        private TeamMaterialUtil teamMaterialUtil = null;

        [SerializeField]
        private Team team = Team.None;

        [SerializeField]
        [Range(1, 10)]
        private float shootTime = 3;

        [SerializeField]
        [Range(1, 1000)]
        private float shootForce = 1000;
        #endregion

        #region Fields
        private float timeOfLastShot = 0;

        private Vector3 fireDirection = Vector3.zero;
        #endregion

        #region Input Fields
        private Vector2 aimInput = Vector2.zero;
        #endregion

        #region Properties
        public Team Team { get => team; set { team = value; meshRenderer.material = teamMaterialUtil.GetMaterialFromTeam(team); } }
        #endregion

        // Update is called once per frame
        void FixedUpdate()
        {
            fireDirection = new Vector3(aimInput.x, 0, aimInput.y);

            // calculate move direction
            if (playerCamera != null)
            {
                Vector3 camForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0, 1)).normalized;

                fireDirection = (fireDirection.z * camForward + fireDirection.x * playerCamera.right).normalized;
            }

            indicator.gameObject.SetActive(fireDirection != Vector3.zero);
        }

        private void LateUpdate()
        {
            indicator.position = fireDirection + indicatorOffset + body.position;
            indicator.rotation = fireDirection == Vector3.zero ? Quaternion.identity : Quaternion.LookRotation(fireDirection);
        }

        void OnAim(InputValue input)
        {
            aimInput = input.Get<Vector2>();
        }

        void OnFire()
        {
            if (Time.time - timeOfLastShot >= shootTime)
            {
                GameObject flyer = Instantiate(flyerPrefab, indicator.position, indicator.rotation);

                Rigidbody flyerRigidBody = flyer.GetComponent<Rigidbody>();

                flyerRigidBody.AddRelativeForce(Vector3.forward * shootForce, ForceMode.Impulse);

                FlyerScript flyerScript = flyer.GetComponent<FlyerScript>();

                flyerScript.Team = team;

                timeOfLastShot = Time.time;
            }
        }
    }
}