using UnityEngine;

public class ChaseState : IEnemyState
{
  private EnemyTargetSystem targetSystem;
  private EnemyFSMController fsm;
  private EnemyMovement movement;
  private Attack enemyAttack;
  private EnemyBootstrap enemy;
  private EnemyAttackManager enemyAttackManager;


  public ChaseState(EnemyContext enemyContext, EnemyFSMController fSMController, EnemyAttackManager enemyAttackManager)
  {
    targetSystem = enemyContext.enemyTargetSystem;
    movement = enemyContext.enemyMovement;
    fsm = fSMController;
    enemy = enemyContext.enemy;
    enemyAttack = enemyContext.enemyAttack;
    this.enemyAttackManager = enemyAttackManager;
  }

  public void Update()
  {
    if (targetSystem.TargetTr != null)
    {

      Vector3 offset = targetSystem.TargetTr.position - enemy.transform.position;
      offset.y = 0f;
      float distanceSqr = offset.sqrMagnitude;

      if (distanceSqr <= enemyAttack.RangeAttack * enemyAttack.RangeAttack)
      {
        movement.StopMove();
        fsm.SwitchState(enemy.AttackSt);
        return;
      }
      Vector3 dir = offset.normalized;

      if (!enemyAttackManager.isAttacking)
        movement.SetDirection(dir);

    }
    else
    {
      fsm.SwitchState(enemy.IdleSt);
      movement.StopMove();
    }
  }
  public void Exit()
  {

  }

  public void Enter()
  {

  }

}