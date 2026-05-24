
using UnityEngine;


public class PlayerBootstrap : MonoBehaviour
{
    public PlayerConfig config;
    private PlayerStats playerStats;
    private PlayerMovement movement;
    private PlayerHealth health;
    private PlayerCombat playerCombat;

    public void Awake()
    {

        GetAllComponents();
        playerStats = new PlayerStats(config);

        if (movement == null && health == null && playerCombat == null) return;
        movement.Init(playerStats);
        health.Init(playerStats.Health);
        playerCombat.InitBaseStats(playerStats);
    }

    public void GetAllComponents()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<PlayerHealth>();
        playerCombat = GetComponent<PlayerCombat>();
    }
}
