using UnityEngine;

public class AttackState : IEnemyState
{
  private EnemyTargetSystem targetSystem;
  private EnemyFSMController fsm;
  private Attack enemyAttack;
  private EnemyBootstrap enemy;
  private EnemyMovement movement;
  private EnemyAttackManager attackManager;
  private float angleAttack = 10f;


  public AttackState(EnemyContext enemyContext, EnemyFSMController fSMController, EnemyAttackManager attackManager)
  {
    targetSystem = enemyContext.enemyTargetSystem;
    movement = enemyContext.enemyMovement;
    fsm = fSMController;
    enemy = enemyContext.enemy;
    enemyAttack = enemyContext.enemyAttack;
    this.attackManager = attackManager;
  }

  public void Update()
  {
    if (targetSystem.TargetTr != null)
    {
      Vector3 offset = targetSystem.TargetTr.position - enemy.transform.position;
      offset.y = 0f;
      float distanceSqr = offset.sqrMagnitude;
      Quaternion targetRotation = Quaternion.LookRotation(offset);
      enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, targetRotation, 5f * Time.deltaTime);
      float angle = Vector3.Angle(enemy.transform.forward, offset);
      if (distanceSqr >= enemyAttack.RangeAttack * enemyAttack.RangeAttack)
      {
        fsm.SwitchState(enemy.ChaseSt);
        return;
      }
      if (angle <= angleAttack)
      {
        attackManager.ManageAttack();
      }

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
    movement.StopMove(); // to stop move during attack . But it does not work correctly;
  }

}