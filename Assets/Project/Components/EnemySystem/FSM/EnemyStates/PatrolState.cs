

using UnityEngine;

public class PatrolState : IEnemyState
{
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyFSMController fsm;
  private EnemyBootstrap enemy;
  private EnemyMovement movement;
  private float patrolTime = 3f;
  private float radius;
  private float timer;
  private Vector3 patrolPoint;
  public PatrolState(float movementRadius, EnemyTargetSystem targetSystem, EnemyFSMController enemyFSMController, EnemyBootstrap enemy, EnemyMovement enemyMovement)
  {
    fsm = enemyFSMController;
    enemyTargetSystem = targetSystem;
    this.enemy = enemy;
    movement = enemyMovement;
    radius = movementRadius;
  }
  public void Update()
  {
    if (enemyTargetSystem.TargetTr != null)
    {
      fsm.SwitchState(enemy.ChaseSt);
    }


    timer -= Time.deltaTime;
    Vector3 dir = (patrolPoint - enemy.transform.position).normalized;
    movement.SetDirection(dir);

    float distance = Vector3.Distance(enemy.transform.position, patrolPoint);
    Debug.Log("patrol");
    //if (distance < 1f || timer <= 0f)
    if (timer <= 0f)
    {
      fsm.SwitchState(enemy.IdleSt);
    }
  }

  public void Enter()
  {
    Vector2 randomCircle = Random.insideUnitCircle * radius;
    patrolPoint = movement.SpawnPosition + new Vector3(randomCircle.x, 0, randomCircle.y);
    timer = patrolTime;
  }
  public void Exit()
  {

    movement.StopMove();
  }
}