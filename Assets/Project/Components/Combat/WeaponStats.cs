using UnityEngine;

public class WeaponStats
{
  private float weaponDamage;
  private float baseWeaponDamage;
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
          weaponDamage * 5 +
          attackRange * 2 +
          attackSpeed * 10
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
    baseWeaponDamage = weaponDamage;
    attackCooldown = config.cooldown;
    attackRange = config.range;
    weaponLevel = 1;
  }

  public void WeaponDamageScaling(float scale)
  {
    weaponDamage = baseWeaponDamage * scale;
  }
}