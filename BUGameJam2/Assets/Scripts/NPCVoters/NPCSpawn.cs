using Assets.Scripts.NPCVoters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    #region Inspector Fields
    [Header("Prefabs")]
    [SerializeField]
    private Transform npcPrefab = null;

    [Header("Containers")]
    [SerializeField]
    private Transform locationContainer = null;

    [SerializeField]
    private Transform npcContainer = null;

    [SerializeField]
    private PlayerManager playerManager = null;

    [Header("Voting Objects")]
    [SerializeField]
    private NPCVoteEnd npcVoteEnder = null;

    [SerializeField]
    private Transform votingStation = null;

    [Header("Utility Objects")]
    [SerializeField]
    private Timer gameTimer = null;

    [Header("Settings")]
    [SerializeField]
    [Range(1, 500)]
    private int npcLimit = 1;

    [SerializeField]
    [Range(0, 10)]
    private float cooldown = 5f;
    #endregion

    private float timeOfLastSpawn = 0;

    public int NPCCount => npcContainer.childCount;

    public int MaxCount => npcLimit;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(NPCCount < npcLimit && Time.time - timeOfLastSpawn >= cooldown)
        {
            spawnNPC(1);

            timeOfLastSpawn = Time.time;
        }
    }

    

    private void spawnNPC(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newNPC = Instantiate(npcPrefab.gameObject, transform.GetChild(Random.Range(0, transform.childCount)).position, Quaternion.identity, npcContainer);

            NPCMovement npcMoveScript = newNPC.GetComponent<NPCMovement>();

            npcMoveScript.locationContainer = locationContainer;
            npcMoveScript.votingStation = votingStation;

            NPCShoot npcShoot = newNPC.GetComponent<NPCShoot>();

            npcShoot.playerManager = playerManager;

            // When the npc votes, count it with the vote counter.
            npcMoveScript.OnVoted.AddListener(() => npcVoteEnder.CountVote(npcMoveScript));

            gameTimer.Finished.AddListener(npcMoveScript.GoVote);

        }
    }
}
