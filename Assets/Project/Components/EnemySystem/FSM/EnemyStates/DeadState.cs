




using System.Collections;
using UnityEngine;

public class DeadState : IEnemyState
{
  private EnemyFSMController fsm;
  private EnemyAnimationsController animationController;

  public DeadState(EnemyFSMController fsm, EnemyAnimationsController animationController)
  {
    this.fsm = fsm;
    this.animationController = animationController;
  }

  public void Update()
  {

  }

  public void Enter()
  {

    fsm.enabled = false;
    animationController.DeadAnimation();
    fsm.StartDestroyCoroutine();
  }
  public void Exit()
  {


  }
}