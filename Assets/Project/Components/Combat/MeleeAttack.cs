using UnityEngine;

public class MeleeAttack : Attack
{
  private ICombatStats combatStats;
  public SwordHitBox swordHitBox;

  void Awake()
  {
    combatStats = GetComponent<ICombatStats>();

  }

  protected override void ExecuteAttack()
  {
    if (combatStats == null) return;
    float totalDamage = combatStats.Damage + attackConfig.damage;
    swordHitBox.EnableCollider();
    swordHitBox.SetDamage(totalDamage);
  }


  public void EnableHitbox()
  {
    swordHitBox.EnableCollider();
  }
  public void DisableHitbox()
  {
    swordHitBox.DisableCollider();
  }
}