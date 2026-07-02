using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
  public SpawnZoneConfig spawnZoneConfig;
  public BoxCollider spawnAreaCollider;
  public PlayerBootstrap playerBootstrap;
  public PopupManager popupManager;

  public EnemyManager enemyManager;
  void OnEnable()
  {
    enemyManager.OnRebuildEnemies += SpawnEnemies;
  }

  void OnDisable()
  {
    enemyManager.OnRebuildEnemies -= SpawnEnemies;
  }

  private void Start()
  {
    SpawnEnemies();
  }

  public void SpawnEnemies()
  {
    if (spawnZoneConfig.Enemies == null) return;

    foreach (var item in spawnZoneConfig.Enemies)
    {
      if (item == null || item.prefab == null)
      {
        Debug.Log("EnemyConfig or prefab missing");
        continue;
      }
      EnemyBootstrap enemyBootstrap = Instantiate(item.prefab, GetRandomPosition(), transform.rotation);
      enemyBootstrap.Init(item);

      enemyBootstrap.GetComponent<EnemyRewardSystem>().InitPlayerRef(playerBootstrap);
      EnemyManager.Instance.AddEnemy(enemyBootstrap);
      enemyBootstrap.GetComponent<EnemyHealth>().InitPopupManager(popupManager);

    }
  }

  private Vector3 GetRandomPosition()
  {
    Bounds bounds = spawnAreaCollider.bounds;
    return new Vector3(
         Random.Range(bounds.min.x, bounds.max.x),
         transform.position.y,
         Random.Range(bounds.min.z, bounds.max.z)
     );
  }
}