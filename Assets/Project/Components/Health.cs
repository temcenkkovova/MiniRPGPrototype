using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
  //public float CurrentHealth { get; private set; }
  public float CurrentHealth;
  public float MaxHealth { get; private set; }
  public event Action<float> OnHealthChanged;
  public event Action OnDeath;
  public event Action<float> Damaged; // It needs for show UI notification

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

  public void TakeDamage(float damage)
  {
    if (CurrentHealth <= damage)
    {
      CurrentHealth = 0f;
      OnDeath?.Invoke();
    }
    else
    {
      CurrentHealth -= damage;
      Damaged?.Invoke(damage);
    }

    OnHealthChanged?.Invoke(CurrentHealth);
  }

}