using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.

        [SerializeField]
        private Transform playerCamera = null;

        private Vector3 camForward;

        private Vector2 moveInput = Vector2.zero;

        private void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();
        }


        private void Update()
        {
            // calculate move direction
            if (playerCamera != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0, 1)).normalized;
                move = (moveInput.y * camForward + moveInput.x * playerCamera.right).normalized;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (moveInput.y * Vector3.forward + moveInput.x * Vector3.right).normalized;
            }
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move, false);
        }
    }
}
