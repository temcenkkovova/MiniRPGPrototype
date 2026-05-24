using System;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
  private PlayerAnimations playerAnimations;
  private Attack attack;



  public bool isAttacking = false;
  public event Action<bool> OnAttackStatusChanged;


  void Awake()
  {
    attack = GetComponent<Attack>();
    playerAnimations = GetComponent<PlayerAnimations>();
  }

  void OnEnable()
  {


  }
  public void ManageAttack()
  {
    if (!attack.CanAttack()) return;
    attack.TryAttack();
    playerAnimations.StartAttackAnimation();
  }



}