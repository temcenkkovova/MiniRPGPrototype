using UnityEngine;

public class MeleeAttack : Attack
{
  private ICombatStats combatStats;
  private SwordHitBox swordHitBox;

  void Awake()
  {
    combatStats = GetComponent<ICombatStats>();

  }
  public void InitWeaponHitBox(SwordHitBox hitBox)
  {
    swordHitBox = hitBox;
  }

  protected override void ExecuteAttack()
  {
    if (combatStats == null) return;
    float totalDamage = combatStats.Damage + weaponConfig.damage;
    swordHitBox.SetDamage(totalDamage, gameObject.transform);
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