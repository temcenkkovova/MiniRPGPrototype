using System;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
  private PlayerAnimations playerAnimations;
  private Attack attack;
  private MeleeAttack meleeAttack;
  private PlayerHealth playerHealth;



  public bool isAttacking = false;
  public event Action<bool> OnAttackStatusChanged;


  void Awake()
  {
    attack = GetComponent<Attack>();
    playerAnimations = GetComponent<PlayerAnimations>();
    meleeAttack = GetComponent<MeleeAttack>();
    playerHealth = GetComponent<PlayerHealth>();
    if (meleeAttack && playerAnimations)
    {
      playerAnimations.AttackAnimationStarted += meleeAttack.EnableHitbox;
      playerAnimations.AttackAnimationFinished += meleeAttack.DisableHitbox;
    }

  }

  void OnDisable()
  {
    if (meleeAttack && playerAnimations)
    {
      playerAnimations.AttackAnimationStarted -= meleeAttack.EnableHitbox;
      playerAnimations.AttackAnimationFinished -= meleeAttack.DisableHitbox;
    }

  }
  public void ManageAttack()
  {
    if (!attack.CanAttack()) return;
    if (playerHealth.IsDead) return; // temporary condition
    attack.TryAttack();
    playerAnimations.StartAttackAnimation();
    OnAttackStatusChanged?.Invoke(true);
  }



}