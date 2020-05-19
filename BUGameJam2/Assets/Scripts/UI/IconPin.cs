using Assets.Scripts.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconPin : MonoBehaviour
{
    [SerializeField]
    private Camera camera = null;

    [SerializeField]
    private PlayerManager playerManager = null;

    [SerializeField]
    private Team team = Team.None;

    private RectTransform rectTransform = null;

    private RawImage rawImage = null;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Transform target = (team == Team.RabbitRed) ? playerManager.Player1?.GetComponentInChildren<Animator>().transform : (team == Team.DuckBlue) ? playerManager.Player2?.GetComponentInChildren<Animator>().transform : null;

        rawImage.enabled = target != null;

        if (target != null)
            rectTransform.position = camera.WorldToScreenPoint(target.position);
    }
}
