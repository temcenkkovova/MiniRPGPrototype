
using UnityEngine;


public class PlayerBootstrap : MonoBehaviour
{
    public PlayerConfig config;
    private PlayerStats playerStats;
    private PlayerMovement movement;
    private PlayerHealth health;
    private PlayerCombat playerCombat;
    private PlayerLevel playerLevel;
    private PlayerRespawn playerRespawn;

    public void Awake()
    {

        GetAllComponents();
        playerStats = new PlayerStats(config);

        if (movement == null || health == null || playerCombat == null || playerLevel == null || playerRespawn == null) return;
        movement.Init(playerStats);
        health.Init(playerStats.Health);
        playerCombat.InitBaseStats(playerStats);
        playerLevel.Init(config);
        playerRespawn.Init(playerStats);

    }

    void Start()
    {
        if (playerStats != null || playerLevel != null)
        {
            playerLevel.OnLevelUpdate += playerStats.IncreaseStats;
        }
    }

    public void GetAllComponents()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<PlayerHealth>();
        playerCombat = GetComponent<PlayerCombat>();
        playerLevel = GetComponent<PlayerLevel>();
        playerRespawn = GetComponent<PlayerRespawn>();

    }

    void OnDisable()
    {
        if (playerStats != null || playerLevel != null)
        {
            playerLevel.OnLevelUpdate -= playerStats.IncreaseStats;
        }
    }
}
