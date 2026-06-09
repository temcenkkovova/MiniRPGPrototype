using System;
using UnityEngine;

public class EnemyHealth : Health
{
  // public event Action<Transform> OnDamaged;
  public float HealthPercent => MaxHealth / CurrentHealth;


  void Start()
  {
    ScaleHealth(EnemyManager.Instance.ScalingValue());

  }

  protected override void Die()
  {
    base.Die();
  }


}