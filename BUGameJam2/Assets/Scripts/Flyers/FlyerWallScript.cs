using Assets.Scripts.DataTypes;
using Assets.Scripts.NPCVoters;
using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flyers
{
    public class FlyerWallScript : MonoBehaviour
    {
        [SerializeField]
        private Team team = Team.None;

        [SerializeField]
        private TeamMaterialUtil teamMaterialUtil = null;

        [SerializeField]
        private MeshRenderer posterMesh = null;

        [SerializeField]
        private Light light = null;

        public Team Team => team;

        private void onNPCEnter(Collider other)
        {
            if (team != Team.None && other.TryGetComponent(out NPCInfluence npc))
                npc.TryChangeTeam(team);
        }

        private void onFlyerEnter(Collider other)
        {
            if (other.TryGetComponent(out FlyerScript flyerScript))
            {
                team = flyerScript.Team;

                posterMesh.material = teamMaterialUtil.GetMaterialFromTeam(team);

                switch (team)
                {
                    case Team.None:
                        light.color = Color.white;
                        break;
                    case Team.RabbitRed:
                        light.color = Color.red;
                        break;
                    case Team.DuckBlue:
                        light.color = Color.blue;
                        break;
                }
            }
        }


    }
}