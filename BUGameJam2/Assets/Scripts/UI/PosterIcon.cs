using Assets.Scripts.Flyers;
using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosterIcon : MonoBehaviour
{
    [SerializeField]
    private Camera camera = null;

    [SerializeField]
    private FlyerWallScript flyerWallScript;

    [SerializeField]
    private TeamPosterUtil teamPosterUtil = null;

    private RectTransform rectTransform = null;

    private RawImage rawImage = null;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flyerWallScript?.transform != null)
            rectTransform.position = camera.WorldToScreenPoint(flyerWallScript.GetComponentInChildren<Light>().transform.position);

        if (flyerWallScript != null)
            rawImage.texture = teamPosterUtil.GetTextureFromTeam(flyerWallScript.Team);
    }
}
