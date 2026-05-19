
using UnityEngine;


public class PlayerBootstrap : MonoBehaviour
{
    public PlayerConfig config;
    private PlayerStats playerStats;
    private PlayerMovement movement;

    public void Awake()
    {
        playerStats = new PlayerStats(config);
        GetAllComponents();
    }

    public void Start()
    {
        if (movement == null) return;
        movement.Init(playerStats);
    }

    public void GetAllComponents()
    {
        movement = GetComponent<PlayerMovement>();
    }
}
