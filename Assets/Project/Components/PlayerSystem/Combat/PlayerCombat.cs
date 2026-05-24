using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

  private PlayerStats playerStats;
  public float PlayerDamage => playerStats.BaseDamage;

  public void InitBaseStats(PlayerStats stats)
  {
    playerStats = stats;
  }



}