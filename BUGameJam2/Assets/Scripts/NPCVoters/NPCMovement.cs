using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NPCMovement : MonoBehaviour
{
    public Transform locationContainer = null;

    public Transform votingStation = null;

    private NavMeshAgent agent = null;

    private bool isWandering = true;

    public UnityEvent OnVoted = null;

    void Awake()
    {
        OnVoted = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = getNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //has the npc reached the destination?
        if ((transform.position - agent.destination).sqrMagnitude <= 3)
        {
            if (isWandering)
                agent.destination = getNextTarget();
            else
                OnVoted.Invoke();
        }
    }

    public void GoVote()
    {
        agent.destination = votingStation.position;
        isWandering = false;
    }

    private Vector3 getNextTarget()
    {
        Vector3 nextTarget;

        //generate a random location
        do
        {
            nextTarget = locationContainer.GetChild(Random.Range(0, locationContainer.transform.childCount)).position;

        } while (nextTarget == agent.destination);

        return nextTarget;
    }
}
