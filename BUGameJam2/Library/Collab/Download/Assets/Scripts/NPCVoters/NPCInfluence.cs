using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.DataTypes;
using Assets.Scripts.Utility;

namespace Assets.Scripts.NPCVoters
{
    [RequireComponent(typeof(MeshRenderer))]
    public class NPCInfluence : MonoBehaviour
    {
        [SerializeField]
        private TeamMaterialUtil teamMaterialUtil = null;

        [SerializeField]
        private Team team = Team.None;

        [SerializeField]
        [Range(0, 1)]
        private float changeChance = 0;

        [HideInInspector]
        private MeshRenderer meshRenderer = null;

        public Team Team { get => team; set { team = value; meshRenderer.material = teamMaterialUtil.GetMaterialFromTeam(team); } }

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void TryChangeTeam(Team team)
        {
            // Roll to change team.
            if (Random.value < changeChance) Team = team;


        }
    }
}