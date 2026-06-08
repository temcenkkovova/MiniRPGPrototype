using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
  public List<EnemyConfig> enemyConfigs;
  public PlayerBootstrap playerBootstrap;
  public BoxCollider spawnAreaCollider;

  // This component will get radius between enemy spawn . The Spawn area  . Max enemy count . Scales enemy health and damage based on the player`s Combat Power;
  void Start()
  {
    SpawnEnemy(3);
  }

  public void SpawnEnemy(float spawnDistance)
  {
    if (enemyConfigs == null) return;

    foreach (var item in enemyConfigs)
    {
      if (item == null || item.prefab == null)
      {
        Debug.Log("EnemyConfig or prefab missing");
        continue;
      }
      EnemyBootstrap enemyBootstrap = Instantiate(item.prefab, GetRandomPosition(spawnDistance), transform.rotation);
      enemyBootstrap.Init(item);
      enemyBootstrap.GetComponent<EnemyRewardSystem>().InitPlayerRef(playerBootstrap);

    }
  }

  private Vector3 GetRandomPosition(float spawnDistance)
  {
    Bounds bounds = spawnAreaCollider.bounds;
    return new Vector3(
         Random.Range(bounds.min.x, bounds.max.x),
         transform.position.y,
         Random.Range(bounds.min.z, bounds.max.z)
     );
  }
}