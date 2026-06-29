




using System.Collections;
using UnityEngine;

public class DeadState : IEnemyState
{
  private EnemyFSMController fsm;
  private EnemyAnimationsController animationController;
  private EnemyMovement movement;

  public DeadState(EnemyFSMController fsm, EnemyAnimationsController animationController, EnemyMovement movement)
  {
    this.fsm = fsm;
    this.animationController = animationController;
    this.movement = movement;
  }

  public void Update()
  {

  }

  public void Enter()
  {

    fsm.enabled = false;
    movement.StopMove();
    animationController.DeadAnimation();
    fsm.StartDestroyCoroutine();

  }
  public void Exit()
  {


  }
}