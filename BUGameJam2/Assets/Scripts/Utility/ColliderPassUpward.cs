using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPassUpward : MonoBehaviour
{
    [SerializeField]
    private string messageName = "Collide";

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.SendMessage(messageName, other);
    }
}
