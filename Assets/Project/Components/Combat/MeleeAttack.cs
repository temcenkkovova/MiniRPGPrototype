using UnityEngine;

public class MeleeAttack : Attack
{
  private PlayerCombat playerCombat;
  public SwordHitBox swordHitBox;
  private PlayerAnimations playerAnimations;


  void Awake()
  {
    playerCombat = GetComponent<PlayerCombat>();
    playerAnimations = GetComponent<PlayerAnimations>();
  }

  protected override void ExecuteAttack()
  {
    if (playerCombat == null) return;
    float totalDamage = playerCombat.PlayerDamage + attackConfig.damage;
    swordHitBox.EnableCollider();
    swordHitBox.SetDamage(totalDamage);
  }

  void OnEnable()
  {

    playerAnimations.AttackAnimationStarted += EnableHitbox;
    playerAnimations.AttackAnimationFinished += DisableHitbox;
  }
  private void EnableHitbox()
  {
    swordHitBox.EnableCollider();
  }
  private void DisableHitbox()
  {
    swordHitBox.DisableCollider();
  }
}