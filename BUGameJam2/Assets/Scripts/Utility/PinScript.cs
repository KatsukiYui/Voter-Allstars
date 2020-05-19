using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private Vector3 offset = Vector3.zero;

    [SerializeField]
    [Range(0, 360)]
    private float lerpSpeed = 50f;

    private Rigidbody targetRigidBody = null;

    public void Start()
    {
        targetRigidBody = target.GetComponent<Rigidbody>();
    }

    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

            Vector3 targetDirection = targetRigidBody.velocity.normalized;


            if (targetDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(targetDirection);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, lerpSpeed * Time.deltaTime);
            }
        }
    }
}
