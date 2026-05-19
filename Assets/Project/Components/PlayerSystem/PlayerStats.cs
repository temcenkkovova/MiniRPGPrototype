using System;

public class PlayerStats
{
  private float health;
  private float moveSpeed;
  public float ExpToNextLevel;
  public float MultiplyExp;
  public float BaseDamage;
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



  public PlayerStats(PlayerConfig config)
  {

  }



}