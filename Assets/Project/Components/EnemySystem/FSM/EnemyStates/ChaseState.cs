using UnityEngine;

public class ChaseState : IEnemyState
{
  private EnemyTargetSystem targetSystem;
  private EnemyFSMController fsm;
  private EnemyMovement movement;
  private EnemyAttack enemyAttack;
  private EnemyBootstrap enemy;

  public ChaseState(EnemyTargetSystem targetSystem, EnemyMovement enemyMovement, EnemyFSMController enemyFSMController, EnemyBootstrap enemy, EnemyAttack enemyAttack)
  {
    this.targetSystem = targetSystem;
    movement = enemyMovement;
    fsm = enemyFSMController;
    this.enemy = enemy;
    this.enemyAttack = enemyAttack;
  }

  public void Update()
  {
    if (targetSystem.TargetTr != null)
    {
      Vector3 offset = targetSystem.TargetTr.position - enemy.transform.position;
      offset.y = 0f;
      float distanceSqr = offset.sqrMagnitude;

      if (distanceSqr <= enemyAttack.attackConfig.range * enemyAttack.attackConfig.range)
      {
        fsm.SwitchState(enemy.AttackSt);
        return;
      }
      Vector3 dir = offset.normalized;


      //movement.Move(dir, movement.enemyConfig.moveSpeed);

    }
    else
    {
      fsm.SwitchState(enemy.IdleSt);
    }
  }
  public void Exit()
  {

  }

  public void Enter()
  {

  }

}