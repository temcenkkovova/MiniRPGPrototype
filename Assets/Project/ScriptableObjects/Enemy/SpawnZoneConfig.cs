using UnityEngine;
[CreateAssetMenu(menuName = "Zone/Enemy")]
public class SpawnZoneConfig : ScriptableObject
{
  public EnemyConfig[] Enemies;
  public int MaxEnemies;
  public float RespawnTime;
}