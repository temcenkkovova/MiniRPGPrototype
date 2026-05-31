using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{

  [NonSerialized] protected WeaponStats weaponStats;
  public float WeaponAttackDamage => weaponStats.WeaponDamage;
  public float RangeAttack => weaponStats.AttackRange;

  protected float lastAttackTime;


  public void Init(WeaponStats weaponStats)
  {

    this.weaponStats = weaponStats;

  }

  public virtual bool CanAttack()
  {
    return Time.time >= lastAttackTime + weaponStats.AttackCooldown;
  }

  public virtual void TryAttack()
  {
    if (!CanAttack()) return;
    ExecuteAttack();
    lastAttackTime = Time.time;
  }

  protected abstract void ExecuteAttack();
}