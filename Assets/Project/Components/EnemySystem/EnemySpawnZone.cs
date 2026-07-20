using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
  public SpawnZoneConfig spawnZoneConfig;
  public BoxCollider spawnAreaCollider;
  public PlayerBootstrap playerBootstrap;
  public PopupManager popupManager;
  public BloodEffectSpawner bloodEffectSpawner;

  private List<EnemyBootstrap> spawned = new List<EnemyBootstrap>();

  public EnemyManager enemyManager;
  void OnEnable()
  {
    enemyManager.OnRebuildEnemies += HandleRebuildWorld;
  }

  void OnDisable()
  {
    enemyManager.OnRebuildEnemies -= HandleRebuildWorld;
  }

  private void Start()
  {
    //SpawnEnemies();
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
      SpawnEnemy(item);

    }
  }
  private void SpawnEnemy(EnemyConfig config)
  {
    EnemyBootstrap enemyBootstrap = Instantiate(config.prefab, GetRandomPosition(), transform.rotation);
    enemyBootstrap.Init(config);
    enemyBootstrap.InitZone(this);
    enemyBootstrap.InitVFX(bloodEffectSpawner);
    enemyBootstrap.GetComponent<EnemyRewardSystem>().InitPlayerRef(playerBootstrap);
    spawned.Add(enemyBootstrap);
    enemyBootstrap.GetComponent<EnemyHealth>().InitPopupManager(popupManager);
  }

  public void SpawnedEnemyDeath(EnemyBootstrap enemy)
  {
    if (!spawned.Contains(enemy)) return;
    spawned.Remove(enemy);
    CheckRespawn();
  }

  private void CheckRespawn()
  {
    if (spawned.Count < spawnZoneConfig.MaxEnemies)
    {
      StartCoroutine(SpawnAfterDelay());
    }
  }

  System.Collections.IEnumerator SpawnAfterDelay()
  {
    yield return new WaitForSeconds(3);
    int randomNumber = Random.Range(0, spawnZoneConfig.MaxEnemies);
    SpawnEnemy(spawnZoneConfig.Enemies[randomNumber]);
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

  private void HandleRebuildWorld()
  {
    foreach (var enemy in spawned)
    {
      Destroy(enemy.gameObject);
    }
    spawned.Clear();
    SpawnEnemies();
  }
}