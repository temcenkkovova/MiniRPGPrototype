using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
  private Animator animator;
  private PlayerMovement movement;

  void Awake()
  {
    animator = GetComponent<Animator>();
    movement = GetComponent<PlayerMovement>();
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
}