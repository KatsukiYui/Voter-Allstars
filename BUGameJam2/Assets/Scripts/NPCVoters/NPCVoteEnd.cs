using Assets.Scripts.DataTypes;
using Assets.Scripts.NPCVoters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCVoteEnd : MonoBehaviour
{
    [SerializeField]
    private NPCSpawn npcSpawn = null;

    private Dictionary<Team, int> voteCounts = null;

    public UnityEvent onLastVoted = null;

    // Start is called before the first frame update
    void Start()
    {
        //onLastVoted = new UnityEvent();

        voteCounts = new Dictionary<Team, int>
        {
            { Team.None, 0 },
            { Team.RabbitRed, 0 },
            { Team.DuckBlue, 0 },
        };
    }

    public int GetVoteCount(Team team) => voteCounts[team];

    public float GetPercentageVoteCount(Team team) => voteCounts[team] / (float)npcSpawn.MaxCount;

    public void CountVote(NPCMovement npcMovement)
    {
        NPCInfluence npcInfluence = npcMovement.GetComponent<NPCInfluence>();

        voteCounts[npcInfluence.Team]++;

        Destroy(npcInfluence.gameObject);

        if (npcSpawn.NPCCount <= 1) onLastVoted.Invoke();
    }

    public Team GetWinner()
    {
        Team winningTeam = Team.None;

        if (voteCounts[Team.DuckBlue] > voteCounts[Team.RabbitRed]) winningTeam = Team.DuckBlue;
        else if (voteCounts[Team.DuckBlue] < voteCounts[Team.RabbitRed]) winningTeam = Team.RabbitRed;
        else winningTeam = Team.None;

        return winningTeam;
    }

    public void ResetVotes()
    {
        voteCounts[Team.None] = 0;
        voteCounts[Team.RabbitRed] = 0;
        voteCounts[Team.DuckBlue] = 0;
    }
}
