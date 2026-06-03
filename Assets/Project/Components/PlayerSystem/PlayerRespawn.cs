using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
  public Transform respawnPos;

  private PlayerMovement playerMovement;
  private CharacterController characterController;

  void Awake()
  {
    playerMovement = GetComponent<PlayerMovement>();
    characterController = GetComponent<CharacterController>();

  }

  public void Respawn()
  {

    characterController.enabled = false; // I need to disable cc during respawn;
    transform.position = respawnPos.position;
    characterController.enabled = true;
  }

}