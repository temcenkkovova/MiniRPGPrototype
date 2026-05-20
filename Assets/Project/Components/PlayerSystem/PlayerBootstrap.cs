
using UnityEngine;


public class PlayerBootstrap : MonoBehaviour
{
    public PlayerConfig config;
    private PlayerStats playerStats;
    private PlayerMovement movement;
    private PlayerHealth health;

    public void Awake()
    {
        playerStats = new PlayerStats(config);
        GetAllComponents();
    }

    public void Start()
    {
        if (movement == null && health == null) return;
        movement.Init(playerStats);
        health.Init(playerStats.Health);
    }

    public void GetAllComponents()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<PlayerHealth>();
    }
}
