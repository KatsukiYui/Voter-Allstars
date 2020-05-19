using Assets.Scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteBarUpdater : MonoBehaviour
{
    [SerializeField]
    private Team team = Team.None;

    [SerializeField]
    private NPCVoteEnd voteEnder = null;

    private RectTransform rectTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3(1, voteEnder.GetPercentageVoteCount(team), 1);
    }
}
