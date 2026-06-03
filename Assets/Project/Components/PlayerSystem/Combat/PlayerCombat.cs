using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombatStats
{

  [NonSerialized] public PlayerStats playerStats;
  public float Damage => playerStats.BaseDamage;
  // public float PlayerBP => playerStats.PlayerPower;


  public void InitBaseStats(PlayerStats stats)
  {
    playerStats = stats;
  }



}