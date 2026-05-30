using System;
using UnityEngine;

public class EnemyAnimationsController : MonoBehaviour
{
  private Animator animator;
  private EnemyMovement movement;


  void Start()
  {
    animator = GetComponentInChildren<Animator>();
    movement = GetComponent<EnemyMovement>();
  }

  public void AttackAnimation()
  {
    animator.SetTrigger("Attack");
  }

  public void MoveAnimation()
  {

    animator.SetFloat("WalkSpeed", movement.CurrentEnemySpeedPercent, 0.1f, Time.deltaTime);

  }
  public void DeadAnimation()
  {
    animator.SetTrigger("Dead");
  }

  void Update()
  {
    if (movement == null) return;
    MoveAnimation();
  }
  public void StartAttackAnimation()
  {

    animator.SetTrigger("Attack");
  }


}