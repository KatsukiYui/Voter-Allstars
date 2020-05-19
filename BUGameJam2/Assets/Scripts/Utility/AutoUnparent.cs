using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class AutoUnparent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            transform.parent = null;
            Destroy(this);
        }
    }
}