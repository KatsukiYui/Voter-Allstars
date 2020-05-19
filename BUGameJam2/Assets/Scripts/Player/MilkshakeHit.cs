using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

public class MilkshakeHit : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 30.0f)]
    private float duration = 2.0f;

    private PlayerMoveScript playerMove = null;

    //private Rigidbody rigidbody = null;

    void Start()
    {
        playerMove = GetComponent<PlayerMoveScript>();
        //rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Milkshake"))
        {
            Destroy(collision.gameObject);
            //rigidbody.velocity = Vector3.zero;
            playerMove.DisableMovementForSeconds(duration);

        }
    }

}
