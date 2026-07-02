using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

  private List<EnemyBootstrap> spawnedEnemies = new List<EnemyBootstrap>();

  public List<EnemyBootstrap> SpawnedEnemies => spawnedEnemies;
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

  public void AddEnemy(EnemyBootstrap newEnemy)
  {
    if (spawnedEnemies.Contains(newEnemy)) return;
    spawnedEnemies.Add(newEnemy);
  }

  // public void RemoveEnemy(EnemyBootstrap enemy)
  // {
  //   if (!spawnedEnemies.Contains(enemy)) return;

  //   spawnedEnemies.Remove(enemy);
  //   CallEnemySpawn();
  // }
  // public void CallEnemySpawn()
  // {
  //   if (spawnedEnemies.Count != maxEnemies)
  //   {
  //     while (spawnedEnemies.Count < maxEnemies)
  //     {
  //       enemySpawnSystem.SpawnEnemy();
  //     }
  //   }
  // }
  public float ScalingValue()
  {

    float scale = 1f + playerTotalPower.BattlePower * 0.02f;
    return scale;
  }

  public void RebuildEnemyWorld(bool isSafeZone)
  {
    if (isSafeZone) return;
    if (playerTotalPower.BattlePower <= lastSpawnBattlePower - 30 || playerTotalPower.BattlePower >= lastSpawnBattlePower + 30)
    {
      lastSpawnBattlePower = playerTotalPower.BattlePower;
      foreach (var enemy in spawnedEnemies)
      {
        Destroy(enemy.gameObject);
      }
      spawnedEnemies.Clear();
      //enemySpawnSystem.SpawnEnemies();
      OnRebuildEnemies?.Invoke();
    }

  }

  void OnDisable()
  {
    if (playerSafeZone == null) return;
    playerSafeZone.OnSafeZone -= RebuildEnemyWorld;
  }
}