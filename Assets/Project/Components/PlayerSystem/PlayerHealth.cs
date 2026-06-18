using UnityEngine;


public class PlayerHealth : Health
{
  private PlayerStats playerStats;

  void OnEnable()
  {

  }
  protected override void Die()
  {
    base.Die();

  }

  public void InitPlayerHealth(PlayerStats playerStats)
  {
    this.playerStats = playerStats;
  }
  public void SetMaxHealth()
  {
    ResetMaxHealth(playerStats.Health);
  }


}