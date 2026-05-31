using UnityEngine;

public class WeaponStats
{
  private float weaponDamage;
  private float attackCooldown;
  private float attackRange;
  private int weaponLevel;

  public float WeaponDamage => weaponDamage;
  public float AttackCooldown => attackCooldown;
  public float AttackRange => attackRange;
  public int Level => weaponLevel;

  public int CombatPower
  {
    get
    {
      float attackSpeed = 1f / Mathf.Max(attackCooldown, 0.01f);

      return Mathf.RoundToInt(
          weaponDamage * 10 +
          attackRange * 5 +
          attackSpeed * 20
      //           + CritChance * 5
      // + CritMultiplier * 10
      // + BonusEffectsPower
      );
    }
  }

  public void LevelUp()
  {
    weaponLevel++;
    weaponDamage *= 1.1f;
    attackCooldown *= 0.95f;
  }
  public WeaponStats(WeaponConfig config)
  {
    weaponDamage = config.damage;
    attackCooldown = config.cooldown;
    attackRange = config.range;
    weaponLevel = 1;
  }
}