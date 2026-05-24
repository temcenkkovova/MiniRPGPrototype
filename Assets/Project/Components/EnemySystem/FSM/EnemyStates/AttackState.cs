using UnityEngine;

public class AttackState : IEnemyState
{
  private EnemyTargetSystem targetSystem;
  private EnemyFSMController fsm;
  private EnemyAttack enemyAttack;
  private EnemyBootstrap enemy;
  private EnemyMovement movement;


  public AttackState(EnemyContext enemyContext, EnemyFSMController fSMController)
  {
    targetSystem = enemyContext.enemyTargetSystem;
    movement = enemyContext.enemyMovement;
    fsm = fSMController;
    enemy = enemyContext.enemy;
    enemyAttack = enemyContext.enemyAttack;
  }

  public void Update()
  {
    if (targetSystem.TargetTr != null)
    {
      Vector3 offset = targetSystem.TargetTr.position - enemy.transform.position;
      offset.y = 0f;
      float distanceSqr = offset.sqrMagnitude;
      if (distanceSqr >= enemyAttack.attackConfig.range * enemyAttack.attackConfig.range)
      {
        fsm.SwitchState(enemy.ChaseSt);
        return;
      }

      Debug.Log("here will be attack action");
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