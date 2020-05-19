using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public Transform locationContainer = null;

    private float moveSpeed = 2.0f;

    private Transform targetTransform = null;

    private NavMeshAgent agent = null;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        targetTransform = getNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //has the npc reached the destination?
        if ((transform.position - targetTransform.position).sqrMagnitude <= 3)
        {
            targetTransform = getNextTarget();
        }

        else
        {
            agent.destination = targetTransform.position;
        }

    }

    private Transform getNextTarget()
    {
        Transform nextTarget = null;

        //generate a random location
        do
        {
            nextTarget = locationContainer.GetChild(Random.Range(0, locationContainer.transform.childCount));

        } while (nextTarget == targetTransform);

        return nextTarget;
    }
}
