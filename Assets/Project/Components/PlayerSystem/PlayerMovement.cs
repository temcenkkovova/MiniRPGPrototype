using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PlayerStats playerStats;
  public float MoveSpeed => playerStats.MoveSpeed;
  private CharacterController characterController;
  private Vector3 planarMoveDirection;
  public Vector3 RotateDirection => planarMoveDirection;

  float gravity = -9.81f;
  float verticalVelocity;
  public void Init(PlayerStats playerData)
  {
    playerStats = playerData;
    characterController = GetComponent<CharacterController>();
  }

  public void Move(Vector2 input)
  {
    Vector3 forward = Camera.main.transform.forward;
    Vector3 right = Camera.main.transform.right;
    forward.y = 0;
    right.y = 0;
    forward.Normalize();
    right.Normalize();
    if (characterController == null) return;
    if (verticalVelocity < 0)
      verticalVelocity = -2f;

    verticalVelocity += gravity * Time.deltaTime;
    planarMoveDirection = forward * input.y + right * input.x; ;
    Vector3 finalMove = planarMoveDirection;
    finalMove.y = verticalVelocity;
    characterController.Move(finalMove * MoveSpeed * Time.deltaTime);


  }

}