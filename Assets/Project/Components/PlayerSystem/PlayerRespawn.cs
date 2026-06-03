using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
  public Transform respawnPos;

  private PlayerHealth playerHealth;
  private CharacterController characterController;
  private PlayerStats playerStats;


  void Awake()
  {

    characterController = GetComponent<CharacterController>();
    playerHealth = GetComponent<PlayerHealth>();

  }
  public void Init(PlayerStats playerStats)
  {
    this.playerStats = playerStats;
  }

  public void Respawn()
  {
    if (characterController == null) return;
    characterController.enabled = false; // I need to disable cc during respawn;
    transform.position = respawnPos.position;
    characterController.enabled = true;
    ResetStats();
  }

  private void ResetStats()
  {
    if (playerHealth == null) return;
    playerHealth.ResetMaxHealth(playerStats.Health);
  }

}