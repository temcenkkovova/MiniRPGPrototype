using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  public float BaseDamage => playerStats.BaseDamage;
  private PlayerStats playerStats;
  [SerializeField] private AttackConfig attackConfig;

  public void InitBaseStats(PlayerStats stats)
  {
    playerStats = stats;
  }



}