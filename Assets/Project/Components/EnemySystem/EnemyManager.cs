using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public static EnemyManager Instance;
  public PlayerTotalPower playerTotalPower;
  public PlayerSafeZone playerSafeZone;
  private int lastSpawnBattlePower;

  public event Action OnRebuildEnemies;

  void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    if (playerTotalPower == null || playerSafeZone == null) return;
    playerSafeZone.OnSafeZone += RebuildEnemyWorld;
    lastSpawnBattlePower = playerTotalPower.BattlePower;
  }
  public float ScalingValue()
  {

    float scale = 1f + playerTotalPower.BattlePower * 0.003f;
    return scale;
  }

  public void RebuildEnemyWorld(bool isSafeZone)
  {
    if (isSafeZone) return;
    if (playerTotalPower.BattlePower <= lastSpawnBattlePower - 30 || playerTotalPower.BattlePower >= lastSpawnBattlePower + 30)
    {
      lastSpawnBattlePower = playerTotalPower.BattlePower;
      OnRebuildEnemies?.Invoke();
    }

  }

  void OnDisable()
  {
    if (playerSafeZone == null) return;
    playerSafeZone.OnSafeZone -= RebuildEnemyWorld;
  }
}