using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform NPC = null;

    [SerializeField]
    private Transform locationContainer = null;

    //make an array of all the spawn positions
    private GameObject[] spawnPositions;

    private int numOfPositions = 0;

    [SerializeField]
    private int totalNumOfNPCs = 0; //total number of npcs in the entire map

    [SerializeField]
    private int maxNumOfNPCs = 0; //max number of npcs that can be in the map at once

    private int numToSpawn = 0; //number of npcs that will spawn from the current spawn position
    private int currentSpawnPos = 0; //index to the spawn position currently being used

    void Awake()
    {
       
        spawnPositions = GameObject.FindGameObjectsWithTag("Spawn");
        numOfPositions = spawnPositions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalNumOfNPCs < maxNumOfNPCs && currentSpawnPos < numOfPositions)
        {
            //randomise the number of npcs to spawn
            do
            {
                numToSpawn = Random.Range(1, (maxNumOfNPCs - totalNumOfNPCs));

            } while (totalNumOfNPCs + numToSpawn > maxNumOfNPCs);

            SpawnNPCs();

            currentSpawnPos++; //move to the next spawn position
            if (currentSpawnPos == numOfPositions - 1)
            {
                currentSpawnPos = 0;
            }

            totalNumOfNPCs += numToSpawn;
        }
    }

    private void SpawnNPCs()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            GameObject newNPC = Instantiate(NPC.gameObject, spawnPositions[currentSpawnPos].transform);

            NPCMovement npcMoveScript = newNPC.GetComponent<NPCMovement>();

            npcMoveScript.locationContainer = locationContainer;

        }
    }
}
