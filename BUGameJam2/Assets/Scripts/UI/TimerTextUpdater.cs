using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextUpdater : MonoBehaviour
{
    [SerializeField]
    private Timer timer = null;

    private Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        text.text = $" Time: {timer.Remaining:F2}";
    }
}
