using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 600)]
    private float lengthInSeconds = 1;

    [SerializeField]
    private UnityEvent begun = null;

    [SerializeField]
    private UnityEvent finished = null;

    public UnityEvent Begun => begun;

    public UnityEvent Finished => finished;

    public float Elapsed { get; private set; } = 0;

    public float Remaining => (float)Math.Round(Mathf.Max(0, lengthInSeconds - Elapsed), 2);

    public bool IsRunning { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsRunning)
        {
            Elapsed += Time.fixedDeltaTime;

            if (Elapsed >= lengthInSeconds)
            {
                finished?.Invoke();
                IsRunning = false;
            }
        }
    }

    public void Begin()
    {
        Elapsed = 0;
        IsRunning = true;
        begun?.Invoke();
    }
}
