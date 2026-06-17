using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
  //public float CurrentHealth { get; private set; }
  public float CurrentHealth;
  public float MaxHealth { get; private set; }
  public event Action<float> OnHealthChanged;
  public event Action OnDeath;
  public float scaledMaxHealth;
  public event Action<DamageInfo> OnDamaged; // It needs for show UI notification
  public bool IsDead { get; private set; }

  protected virtual void Die()
  {
    OnDeath?.Invoke();
    IsDead = true;
  }

  public void Init(float maxHealth)
  {
    CurrentHealth = maxHealth;
    MaxHealth = maxHealth;
    OnHealthChanged?.Invoke(maxHealth);
  }

  public void TakeDamage(float damage, Transform attacker)
  {
    if (CurrentHealth <= 0) return;
    if (CurrentHealth <= damage)
    {
      CurrentHealth = 0f;
      OnDamaged?.Invoke(new DamageInfo
      {
        Damage = damage,
        attacker = attacker
      });
      Die();
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

  public void Respawn()
  {
    IsDead = false;

  }

  public void ResetHealth()
  {
    CurrentHealth = scaledMaxHealth;
    OnHealthChanged?.Invoke(CurrentHealth);
  }

  public void ScaleHealth(float scale)
  {

    scaledMaxHealth = MaxHealth * scale;
    CurrentHealth = scaledMaxHealth;
    OnHealthChanged?.Invoke(CurrentHealth);
  }
}