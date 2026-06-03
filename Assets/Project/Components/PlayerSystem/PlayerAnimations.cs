using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
  private Animator animator;
  private PlayerMovement movement;
  private PlayerHealth playerHealth;
  public event Action AttackAnimationFinished;
  public event Action AttackAnimationStarted;

  void Awake()
  {
    animator = GetComponent<Animator>();
    movement = GetComponent<PlayerMovement>();
    playerHealth = GetComponent<PlayerHealth>();
  }
  void Start()
  {
    if (playerHealth == null) return;
    playerHealth.OnDeath += PlayDeathAnimation;




  }


  public void Update()
  {
    if (movement == null) return;
    animator.SetFloat("MoveSpeed", movement.CurrentSpeedPercent, 0.1f, Time.deltaTime);
  }

  public void StartAttackAnimation()
  {
    animator.SetTrigger("Attack");
  }

  public void OnAttackAnimationStarted()
  {
    AttackAnimationStarted?.Invoke();
  }
  public void OnAttackAnimationFinished()
  {
    AttackAnimationFinished?.Invoke();

  }


  public void PlayDeathAnimation()
  {
    animator.SetTrigger("Dead");
  }
}