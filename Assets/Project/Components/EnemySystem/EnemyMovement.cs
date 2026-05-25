using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  private EnemyConfig enemyConfig;
  private Rigidbody rb;
  private Vector3 moveDirection;
  private float rotateSpeed = 5f;
  public float CurrentEnemySpeedPercent { get; private set; }
  public Vector3 SpawnPosition { get; private set; }


  public void Init(EnemyConfig enemyConfig)
  {
    this.enemyConfig = enemyConfig;
  }

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    SpawnPosition = transform.position;
  }

  public void SetDirection(Vector3 direction)
  {
    moveDirection = direction;
  }
  private void FixedUpdate()
  {
    if (enemyConfig)
    {
      rb.velocity = moveDirection * enemyConfig.moveSpeed;
      CurrentEnemySpeedPercent = moveDirection.sqrMagnitude > 0.01f ? 1f : 0f;
      Vector3 rotateDir = moveDirection;
      rotateDir.y = 0f;
      if (rotateDir.sqrMagnitude < 0.01f) return;
      Quaternion targetRotation = Quaternion.LookRotation(rotateDir);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

  }

  public void StopMove()
  {
    moveDirection = Vector3.zero;
    rb.velocity = moveDirection;
  }


}