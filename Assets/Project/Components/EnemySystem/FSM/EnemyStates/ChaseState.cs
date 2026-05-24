using UnityEngine;

public class ChaseState : IEnemyState
{
  private Transform target;
  private EnemyMovement movement;

  public ChaseState(Transform tr, EnemyMovement enemyMovement)
  {
    target = tr;
    movement = enemyMovement;
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