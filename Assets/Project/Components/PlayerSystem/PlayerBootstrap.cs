
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
    private PlayerStatsUIManager playerStatsUIManager;
    private PlayerTotalPower playerTotalPower;

    public void Awake()
    {

        GetAllComponents();
        playerStats = new PlayerStats(config);

        if (movement == null || health == null || playerCombat == null || playerLevel == null || playerRespawn == null || playerStatsUIManager == null) return;
        movement.Init(playerStats);
        health.Init(playerStats.Health);
        health.InitPlayerHealth(playerStats);
        playerCombat.InitBaseStats(playerStats);
        playerLevel.Init(config);
        playerRespawn.Init(playerStats);
        playerStatsUIManager.Init(playerTotalPower);

    }

    void Start()
    {
        if (playerLevel == null) return;

        playerLevel.OnLevelUpdate += LevelUpdateActions;
    }

    public void GetAllComponents()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<PlayerHealth>();
        playerCombat = GetComponent<PlayerCombat>();
        playerLevel = GetComponent<PlayerLevel>();
        playerRespawn = GetComponent<PlayerRespawn>();
        playerStatsUIManager = GetComponent<PlayerStatsUIManager>();
        playerTotalPower = GetComponent<PlayerTotalPower>();
    }

    void OnDisable()
    {
        if (playerLevel != null)
        {
            playerLevel.OnLevelUpdate -= LevelUpdateActions;
        }
    }

    private void LevelUpdateActions(int level)
    {
        if (playerStats == null || health == null) return;
        playerStats.IncreaseStats();
        health.SetMaxHealth();
    }
}
