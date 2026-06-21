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
  private Armor armor;
  public bool IsDead { get; private set; }

  void Awake()
  {
    armor = GetComponent<Armor>();
  }
  protected virtual void Die()
  {
    Debug.Log("gea");
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


    if (armor == null) return;
    float reducedDamage = armor.ReduceDamage(damage);
    Debug.Log("Income damage" + reducedDamage);
    Debug.Log("current health " + CurrentHealth);
    if (CurrentHealth <= 0f) return;

    if (CurrentHealth <= reducedDamage)
    {

      CurrentHealth = 0f;
      OnDamaged?.Invoke(new DamageInfo
      {
        Damage = reducedDamage,
        attacker = attacker
      });
      Die();
    }
    else
    {
      CurrentHealth -= reducedDamage;
      OnDamaged?.Invoke(new DamageInfo
      {
        Damage = reducedDamage,
        attacker = attacker
      });

      if (CurrentHealth < 1f)
      {
        Die();
      }
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