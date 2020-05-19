using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class MeshDeleter : MonoBehaviour
    {
        void Start()
        {
            if (TryGetComponent(out MeshRenderer meshRenderer)) Destroy(meshRenderer);
            if (TryGetComponent(out MeshFilter meshFilter)) Destroy(meshFilter);
            Destroy(this);
        }
    }
}