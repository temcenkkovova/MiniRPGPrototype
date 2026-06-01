using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
  public float maxHealth;
  public float moveSpeed;
  public float coinsReward; // I`ll add CurrencyType enum for future if I have another type of Currency . Example : Wood , Stone . For now it`s premature abstraction
  public float expReward;

  public EnemyAudioConfig enemyAudioConfig;

}