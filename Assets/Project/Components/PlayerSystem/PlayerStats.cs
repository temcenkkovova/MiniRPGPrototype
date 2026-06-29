using System;
using UnityEngine;

public class PlayerStats
{
  private float health;
  private float moveSpeed;
  public float armor;
  private float sprintSpeed;
  public float ExpToNextLevel;
  public float MultiplyExp;
  private float baseDamage;
  public float SprintSpeed
  {
    get => sprintSpeed; set
    {
      sprintSpeed = value;
      OnSprintSpeedChanged?.Invoke(sprintSpeed);
    }
  }
  public float Armor
  {
    get => armor; set
    {
      armor = value;
      OnArmorChanged?.Invoke(armor);
      OnStatsChanged?.Invoke();
    }
  }
  public float BaseDamage
  {
    get => baseDamage; set
    {
      baseDamage = value;
      OnBaseDamageChanged?.Invoke(baseDamage);
      OnStatsChanged?.Invoke();
    }
  }
  public float Health
  {
    get => health; set
    {
      health = value;
      OnHealthChanged?.Invoke(health);
      OnStatsChanged?.Invoke();
    }
  }
  public event Action<float> OnHealthChanged;
  public event Action<float> OnArmorChanged;

  public float MoveSpeed
  {
    get => moveSpeed; set
    {
      moveSpeed = value;
      OnMoveSpeedChanged?.Invoke(moveSpeed);
      OnStatsChanged?.Invoke();
    }
  }
  public int PlayerPower
  {
    get
    {
      return Mathf.RoundToInt(
          BaseDamage * 3 +
          MoveSpeed * 2 +
          Health * 1
      );
    }
  }
  public event Action<float> OnMoveSpeedChanged;

  public event Action OnStatsChanged;
  public event Action<float> OnBaseDamageChanged;
  public event Action<float> OnSprintSpeedChanged;

  public PlayerStats(PlayerConfig config)
  {
    Health = config.maxHealth;
    MoveSpeed = config.moveSpeed;
    ExpToNextLevel = config.expToNextLevel;
    MultiplyExp = config.multiplyExp;
    BaseDamage = config.baseDamage;
    SprintSpeed = config.sprintSpeed;
    Armor = config.baseArmor;
  }

  public void IncreaseStats()
  {
    BaseDamage *= 1.2f;
    MoveSpeed *= 1.1f;
    Armor += 0.5f;
    Health *= 1.1f;
    SprintSpeed *= 1.1f;
    OnStatsChanged?.Invoke();
  }
}