using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  private EnemyConfig enemyConfig;
  private Rigidbody rb;
  private Vector3 moveDirection;
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
    }

  }

  public void StopMove()
  {
    moveDirection = Vector3.zero;
    rb.velocity = moveDirection;
  }


}