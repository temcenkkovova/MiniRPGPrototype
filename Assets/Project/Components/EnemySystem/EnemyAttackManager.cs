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
  }


  public void ManageAttack()
  {

    if (!attack.CanAttack()) return;
    attack.TryAttack();
    enemyAnimationsController.StartAttackAnimation();
    isAttacking = true;
  }

  public void HandleStartedAttack()
  {


    meleeAttack.EnableHitbox();
  }
  public void HandleFinishedAttack()
  {
    isAttacking = false;
    meleeAttack.DisableHitbox();
  }

  void OnEnable()
  {
    isAttacking = false;

    if (meleeAttack && animationEvents)
    {
      animationEvents.AttackAnimationStarted += HandleStartedAttack;
      animationEvents.AttackAnimationFinished += HandleFinishedAttack;
    }
  }

  void OnDisable()
  {
    if (meleeAttack && animationEvents)
    {
      animationEvents.AttackAnimationStarted -= HandleStartedAttack;
      animationEvents.AttackAnimationFinished -= HandleFinishedAttack;
    }

  }
}