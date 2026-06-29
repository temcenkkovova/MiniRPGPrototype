
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

  public void HandleRespawn()
  {
    if (characterController == null || playerHealth == null) return;
    characterController.enabled = false; // I need to disable cc during respawn;
    transform.position = respawnPos.position;
    characterController.enabled = true;
    playerHealth.Respawn();
    playerHealth.ResetMaxHealth(playerStats.Health);

  }
  public void HandleLoadedPosition(Vector3 loadedPos)
  {
    if (characterController == null) return;
    characterController.enabled = false;
    transform.position = loadedPos;
    characterController.enabled = true;
  }



}