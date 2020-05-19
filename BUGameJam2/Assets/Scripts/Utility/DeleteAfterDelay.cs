using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterDelay : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 100)]
    private float seconds = 1;

    private void Start()
    {
        StartCoroutine(deleteAfterSeconds());
    }

    IEnumerator deleteAfterSeconds()
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }
}
