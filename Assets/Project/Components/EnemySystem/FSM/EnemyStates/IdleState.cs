

using UnityEngine;

public class IdleState : IEnemyState
{
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyFSMController fsm;
  private EnemyBootstrap enemy;
  public IdleState(float movementRadius, EnemyTargetSystem targetSystem, EnemyFSMController enemyFSMController, EnemyBootstrap enemy)
  {
    fsm = enemyFSMController;
    enemyTargetSystem = targetSystem;
    this.enemy = enemy;
  }
  public void Update()
  {
    if (enemyTargetSystem.TargetTr != null)
    {
      fsm.SwitchState(enemy.ChaseSt);
    }

    Debug.Log("Idle");
  }

  public void Enter()
  {

  }
  public void Exit()
  {

  }
}