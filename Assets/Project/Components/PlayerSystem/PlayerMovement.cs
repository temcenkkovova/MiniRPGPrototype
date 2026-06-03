using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PlayerStats playerStats;
  private PlayerHealth playerHealth;
  public float MoveSpeed => playerStats.MoveSpeed;
  public float SprintSpeed => playerStats.SprintSpeed;
  private CharacterController characterController;
  private Vector3 planarMoveDirection;
  public Vector3 RotateDirection => planarMoveDirection;
  public float CurrentSpeedPercent { get; private set; }
  public bool isSprinting { get; private set; }
  public bool isMoving { get; private set; }
  public event Action<bool> OnSprintChanged;

  float gravity = -9.81f;
  float verticalVelocity;

  void Awake()
  {
    playerHealth = GetComponent<PlayerHealth>();
  }
  public void Init(PlayerStats playerData)
  {
    playerStats = playerData;
    characterController = GetComponent<CharacterController>();
  }

  public void Move(Vector2 input)
  {
    if (!playerHealth) return;
    if (playerHealth.IsDead) return;
    Vector3 forward = Camera.main.transform.forward;
    Vector3 right = Camera.main.transform.right;
    forward.y = 0;
    right.y = 0;
    forward.Normalize();
    right.Normalize();
    if (characterController == null) return;
    if (verticalVelocity < 0)
      verticalVelocity = -2f;
    float currentSpeed = isSprinting ? SprintSpeed : MoveSpeed;
    verticalVelocity += gravity * Time.deltaTime;
    planarMoveDirection = forward * input.y + right * input.x; ;
    Vector3 finalMove = planarMoveDirection;
    finalMove.y = verticalVelocity;

    CurrentSpeedPercent = planarMoveDirection.sqrMagnitude > 0.01f ? (isSprinting ? 1f : 0.5f) : 0f; // It needs for animation
    characterController.Move(finalMove * currentSpeed * Time.deltaTime);
  }

  public void ChangeSprintState(bool newSprintState)
  {
    if (!playerHealth) return;
    if (playerHealth.IsDead) return;
    if (isSprinting == newSprintState) return;

    isSprinting = newSprintState;
    OnSprintChanged?.Invoke(isSprinting); // It needs for UI
  }
}