using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
  //public float CurrentHealth { get; private set; }
  public float CurrentHealth;
  public float MaxHealth { get; private set; }
  public event Action<float> OnHealthChanged;
  public event Action OnDeath;
  public event Action<DamageInfo> OnDamaged; // It needs for show UI notification

  protected virtual void Die()
  {
    OnDeath?.Invoke();
  }

  public void Init(float maxHealth)
  {
    CurrentHealth = maxHealth;
    MaxHealth = maxHealth;
    OnHealthChanged?.Invoke(maxHealth);
  }

  public void TakeDamage(float damage, Transform attacker)
  {
    if (CurrentHealth <= damage)
    {
      CurrentHealth = 0f;
      OnDeath?.Invoke();
    }
    else
    {
      CurrentHealth -= damage;
      OnDamaged?.Invoke(new DamageInfo
      {
        Damage = damage,
        attacker = attacker
      });
    }

    OnHealthChanged?.Invoke(CurrentHealth);
  }
  public void ResetMaxHealth(float maxHealth)
  {
    CurrentHealth = maxHealth;
    OnHealthChanged?.Invoke(CurrentHealth);
  }

}