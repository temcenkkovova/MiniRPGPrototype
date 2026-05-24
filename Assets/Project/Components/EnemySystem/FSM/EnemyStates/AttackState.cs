using UnityEngine;

public class AttackState : IEnemyState
{
  private EnemyTargetSystem targetSystem;
  private EnemyFSMController fsm;
  private EnemyAttack enemyAttack;
  private EnemyBootstrap enemy;

  public AttackState(EnemyTargetSystem targetSystem, EnemyFSMController enemyFSMController, EnemyBootstrap enemy, EnemyAttack enemyAttack)
  {
    Debug.Log("Enemy is attacking");
  }

  public void Update()
  {

  }
  public void Exit()
  {

  }

  public void Enter()
  {

  }

}