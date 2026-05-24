

using UnityEngine;

public class IdleState : IEnemyState
{
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyFSMController fsm;
  private EnemyBootstrap enemy;
  private float idleTime = 2f;
  private float timer;

  public IdleState(EnemyContext enemyContext, EnemyFSMController fSMController)
  {
    enemyTargetSystem = enemyContext.enemyTargetSystem;
    fsm = fSMController;
    enemy = enemyContext.enemy;

  }
  public void Update()
  {
    if (enemyTargetSystem.TargetTr != null)
    {
      fsm.SwitchState(enemy.ChaseSt);
      return;
    }
    else
    {
      timer -= Time.deltaTime;
      Debug.Log("Idle");
      if (timer <= 0f)
      {
        fsm.SwitchState(enemy.PatrolSt);
      }
    }
  }

  public void Enter()
  {
    timer = idleTime;
  }
  public void Exit()
  {

  }
}