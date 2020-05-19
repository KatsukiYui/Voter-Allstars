using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFollower : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position;
            target.localPosition = Vector3.zero;
        }
    }
}
