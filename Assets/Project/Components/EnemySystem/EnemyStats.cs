using System;
using UnityEngine;
// I don`t use this component at the moment !!
public class EnemyStats
{
  private float health;
  private float moveSpeed;

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

  public float MoveSpeed
  {
    get => moveSpeed; set
    {
      moveSpeed = value;
      OnMoveSpeedChanged?.Invoke(moveSpeed);
      OnStatsChanged?.Invoke();
    }
  }
  public event Action<float> OnMoveSpeedChanged;
  public event Action OnStatsChanged;

  public EnemyStats(PlayerConfig config)
  {
    Health = config.maxHealth;
    MoveSpeed = config.moveSpeed;
  }

  public void ApplyScaling()
  {

  }
}