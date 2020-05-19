using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

namespace Assets.Scripts.Player
{
    public class PlayerMoveScript : MonoBehaviour
    {
        private Animator animator = null;

        private BallUserControl ballUserControl = null;

        private Ball ball = null;

        // Start is called before the first frame update
        void Start()
        {
            ballUserControl = GetComponentInChildren<BallUserControl>();
            ball = ballUserControl.GetComponent<Ball>();

            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            animator.speed = 3 * ball.CurrentVelocity / ball.MovePower;
        }

        public void DisableMovementForSeconds(float seconds)
        {
            StartCoroutine("stopMovementForSeconds", seconds);
        }

        IEnumerator stopMovementForSeconds(float seconds)
        {
            ballUserControl.enabled = false;

            yield return new WaitForSeconds(seconds);

            ballUserControl.enabled = true;
        }
    }
}