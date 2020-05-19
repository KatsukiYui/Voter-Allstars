using Assets.Scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TeamMaterialUtil : ScriptableObject
    {
        [SerializeField]
        private Material noTeamMaterial = null;

        [SerializeField]
        private Material redTeamMaterial = null;

        [SerializeField]
        private Material blueTeamMaterial = null;

        public Material GetMaterialFromTeam(Team team)
        {
            switch (team)
            {
                case Team.None:
                    return noTeamMaterial;
                case Team.RabbitRed:
                    return redTeamMaterial;
                case Team.DuckBlue:
                    return blueTeamMaterial;
                default:
                    return null;
            }
        }
    }
}