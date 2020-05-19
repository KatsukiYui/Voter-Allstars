using Assets.Scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TeamPosterUtil : ScriptableObject
    {
        [SerializeField]
        private Texture noTeamTexture = null;

        [SerializeField]
        private Texture redTeamTexture = null;

        [SerializeField]
        private Texture blueTeamTexture = null;

        public Texture GetTextureFromTeam(Team team)
        {
            switch (team)
            {
                case Team.None:
                    return noTeamTexture;
                case Team.RabbitRed:
                    return redTeamTexture;
                case Team.DuckBlue:
                    return blueTeamTexture;
                default:
                    return null;
            }
        }
    }
}