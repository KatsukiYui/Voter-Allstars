using Assets.Scripts.DataTypes;
using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flyers
{
    public class FlyerScript : MonoBehaviour
    {
        [SerializeField]
        private TeamMaterialUtil teamMaterialUtil = null;

        private MeshRenderer meshRendererDontUse = null;

        private Team team = Team.None;

        public Team Team { get => team; set { team = value; meshRenderer.material = teamMaterialUtil.GetMaterialFromTeam(team); } }

        private MeshRenderer meshRenderer { get { if (meshRendererDontUse == null) meshRendererDontUse = GetComponent<MeshRenderer>(); return meshRendererDontUse; } }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}