using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{

  [NonSerialized] protected WeaponConfig weaponConfig;
  public float WeaponAttackDamage => weaponConfig.damage;
  public float RangeAttack => weaponConfig.range;

  protected float lastAttackTime;


  public void Init(WeaponConfig config)
  {

    weaponConfig = config;

  }

  public virtual bool CanAttack()
  {
    return Time.time >= lastAttackTime + weaponConfig.cooldown;
  }

  public virtual void TryAttack()
  {
    if (!CanAttack()) return;
    ExecuteAttack();
    lastAttackTime = Time.time;
  }

  protected abstract void ExecuteAttack();
}