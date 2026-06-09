using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public int maxEnemies = 6;
  private List<EnemyBootstrap> spawnedEnemies = new List<EnemyBootstrap>();
  public EnemySpawnSystem enemySpawnSystem;
  public List<EnemyBootstrap> SpawnedEnemies => spawnedEnemies;
  public static EnemyManager Instance;
  public PlayerTotalPower playerTotalPower;

  void Awake()
  {
    Instance = this;
  }

  public void AddEnemy(EnemyBootstrap newEnemy)
  {
    if (spawnedEnemies.Contains(newEnemy)) return;
    spawnedEnemies.Add(newEnemy);
  }

  public void RemoveEnemy(EnemyBootstrap enemy)
  {
    if (!spawnedEnemies.Contains(enemy)) return;

    spawnedEnemies.Remove(enemy);
    CallEnemySpawn();
  }
  public void CallEnemySpawn()
  {
    if (spawnedEnemies.Count != maxEnemies)
    {
      while (spawnedEnemies.Count < maxEnemies)
      {
        enemySpawnSystem.SpawnEnemy();
      }
    }
  }
  public float ScalingValue()
  {

    float scale = 1f + playerTotalPower.BattlePower * 0.02f;
    return scale;
  }

}