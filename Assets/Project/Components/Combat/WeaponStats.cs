using UnityEngine;

public class WeaponStats
{
  private float weaponDamage;
  private float attackCooldown;
  private float attackRange;

  public int CombatPower =>
    Mathf.RoundToInt(
        weaponDamage * 10 +
        attackRange * 5 +
        (1f / attackCooldown) * 20
    );
}