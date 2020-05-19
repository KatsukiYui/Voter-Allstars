using Assets.Scripts.DataTypes;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Cameras;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform playerContainer = null;

    [SerializeField]
    private Transform spawnContainer = null;

    [SerializeField]
    private RenderTexture redview = null;

    [SerializeField]
    private RenderTexture blueView = null;

    private PlayerInputManager playerInputManager = null;

    /// <summary> The Red player. </summary>
    public ShootScript Player1 { get; private set; }

    /// <summary> The blue player. </summary>
    public ShootScript Player2 { get; private set; }

    private void OnPlayerJoined(PlayerInput player)
    {
        // Get the transform of the player.
        Transform playerTransform = player.transform;

        // Parent the player to the player manager.
        playerTransform.parent = playerContainer;

        // Set the player team.
        ShootScript playerShoot = player.GetComponent<ShootScript>();

        // Set the team of the player.
        if (playerInputManager.playerCount == 1) { Player1 = playerShoot; playerShoot.Team = Team.RabbitRed; player.GetComponentInChildren<Camera>().targetTexture = redview; }
        else if (playerInputManager.playerCount == 2) { Player2 = playerShoot; playerShoot.Team = Team.DuckBlue; player.GetComponentInChildren<Camera>().targetTexture = blueView; }

        Transform spawnPos = spawnContainer.GetChild(playerInputManager.playerCount - 1);

        playerTransform.position = spawnPos.position;
        playerTransform.rotation = spawnPos.rotation;
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
