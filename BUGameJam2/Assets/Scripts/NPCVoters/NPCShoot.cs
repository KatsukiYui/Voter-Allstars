using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.DataTypes;
using Assets.Scripts.Utility;

namespace Assets.Scripts.NPCVoters
{
    public class NPCShoot : MonoBehaviour
    {
        [Header("General Properties")]
        [SerializeField]
        [Range(0.0f, 30.0f)]
        private float cooldown = 5.0f;

        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float hostileChance = 0.5f;

        [SerializeField]
        [Range(0.0f, 30.0f)]
        private float detectionRange = 10.0f;

        [SerializeField]
        [Range(1, 100)]
        private float throwForce = 1;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject milkshakePrefab = null;

        [HideInInspector]
        public PlayerManager playerManager = null;

        private NPCInfluence influence = null;

        private float cooldownTimer = 0.0f;


        void Start()
        {
            influence = GetComponent<NPCInfluence>();

        }

        // Update is called once per frame
        void Update()
        {
            if (influence.Team != Team.None)
            {
                Transform targetPlayer = playerManager.Player1?.Team != influence.Team ? playerManager.Player1?.GetComponentInChildren<Animator>().transform : playerManager.Player2?.GetComponentInChildren<Animator>().transform;
                tryShootPlayer(targetPlayer);
            }
        }


        private void tryShootPlayer(Transform target)
        {
            if (target == null) return;

            if (cooldownTimer <= 0)
            {
                if (Random.value <= hostileChance && (target.position - transform.position).sqrMagnitude <= detectionRange * detectionRange)
                    shootPlayer(target);

                cooldownTimer = cooldown;

            }

            else
                cooldownTimer -= Time.deltaTime;
        }

        private void shootPlayer(Transform target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            GameObject milkShake = Instantiate(milkshakePrefab, transform.position + direction * 2, Quaternion.LookRotation(direction));

            Rigidbody milkshakeRigidBody = milkShake.GetComponent<Rigidbody>();

            milkshakeRigidBody.AddForce(milkShake.transform.rotation.eulerAngles * throwForce, ForceMode.Impulse);
        }
    }
}