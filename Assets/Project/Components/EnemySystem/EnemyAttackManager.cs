using System;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
  private EnemyAnimationsController enemyAnimationsController;
  private Attack attack;
  private MeleeAttack meleeAttack;
  private EnemyAnimationEvents animationEvents;



  public bool isAttacking = false;
  public event Action<bool> OnAttackStatusChanged;


  void Awake()
  {
    attack = GetComponent<Attack>();
    enemyAnimationsController = GetComponent<EnemyAnimationsController>();
    animationEvents = GetComponentInChildren<EnemyAnimationEvents>();
    meleeAttack = GetComponent<MeleeAttack>();
    if (meleeAttack && animationEvents)
    {
      animationEvents.AttackAnimationStarted += meleeAttack.EnableHitbox;
      animationEvents.AttackAnimationFinished += meleeAttack.DisableHitbox;
    }

  }

  void OnDisable()
  {
    if (meleeAttack && animationEvents)
    {
      animationEvents.AttackAnimationStarted -= meleeAttack.EnableHitbox;
      animationEvents.AttackAnimationFinished -= meleeAttack.DisableHitbox;
    }

  }
  public void ManageAttack()
  {
    if (!attack.CanAttack()) return;
    attack.TryAttack();
    enemyAnimationsController.StartAttackAnimation();
  }



}