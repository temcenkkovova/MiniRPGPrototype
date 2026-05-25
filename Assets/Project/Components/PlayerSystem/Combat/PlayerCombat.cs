using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombatStats
{

  private PlayerStats playerStats;
  public float Damage => playerStats.BaseDamage;


  public void InitBaseStats(PlayerStats stats)
  {
    playerStats = stats;
  }



}