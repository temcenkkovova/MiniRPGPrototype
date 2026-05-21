using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
  private PlayerAnimations playerAnimations;
  private Attack attack;

  void Awake()
  {
    attack = GetComponent<Attack>();
    playerAnimations = GetComponent<PlayerAnimations>();

  }
  public void ManageAttack()
  {
    playerAnimations.StartAttackAnimation();
  }


}