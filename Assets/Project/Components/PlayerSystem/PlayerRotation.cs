using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
  private PlayerMovement movement;
  private float RotationSpeed = 5f;
  void Awake()
  {
    movement = GetComponent<PlayerMovement>();
  }

  void Update()
  {
    if (movement == null) return;

    Vector3 direction = movement.RotateDirection;
    direction.y = 0f;
    if (direction.sqrMagnitude < 0.01f)
      return;
    Quaternion targetRotation = Quaternion.LookRotation(direction);

    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
  }
}