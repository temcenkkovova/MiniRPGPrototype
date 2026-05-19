using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PlayerStats playerStats;
  public float MoveSpeed => playerStats.MoveSpeed;
  private CharacterController characterController;

  float gravity = -9.81f;
  float verticalVelocity;
  public void Init(PlayerStats playerData)
  {
    playerStats = playerData;
    characterController = GetComponent<CharacterController>();

  }

  public void Move(Vector3 input)
  {
    if (characterController == null) return;
    if (verticalVelocity < 0)
      verticalVelocity = -2f;

    verticalVelocity += gravity * Time.deltaTime;

    Vector3 move = transform.forward * input.y + transform.right * input.x;
    move *= MoveSpeed;
    move.y = verticalVelocity;
    characterController.Move(move * Time.deltaTime);


  }

}