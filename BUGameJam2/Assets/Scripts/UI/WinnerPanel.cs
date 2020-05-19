using Assets.Scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    [SerializeField]
    private NPCVoteEnd voteManager;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private RectTransform winPanel;

    [SerializeField]
    private RectTransform blueWinPanel;

    [SerializeField]
    private RectTransform redWinPanel;

    public void ShowWinner()
    {
        winText.gameObject.SetActive(true);
        winPanel.gameObject.SetActive(true);

        Team winningTeam = voteManager.GetWinner();
        switch (winningTeam)
        {
            case Team.DuckBlue:
                winText.text = "Blue Ducks Win!";
                blueWinPanel.gameObject.SetActive(true);
                break;
            case Team.RabbitRed:
                winText.text = "Red Rabbits Win!";
                redWinPanel.gameObject.SetActive(true);
                break;
            case Team.None:
                winText.text = "Tie! Both parties disqualified for voter fraud.";
                break;
        }
    }
}
