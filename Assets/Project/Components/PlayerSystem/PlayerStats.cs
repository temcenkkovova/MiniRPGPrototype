using System;

public class PlayerStats
{
  private float health;
  private float moveSpeed;
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
  public float BaseDamage
  {
    get => baseDamage; set
    {
      baseDamage = value;
      OnBaseDamageChanged?.Invoke(baseDamage);
    }
  }
  public float Health
  {
    get => health; set
    {
      health = value;
      OnHealthChanged?.Invoke(health);
    }
  }
  public event Action<float> OnHealthChanged;

  public float MoveSpeed
  {
    get => moveSpeed; set
    {
      moveSpeed = value;
      OnMoveSpeedChanged?.Invoke(moveSpeed);
    }
  }
  public event Action<float> OnMoveSpeedChanged;

  public event Action<PlayerStats> OnStatsChanged;
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
  }
}