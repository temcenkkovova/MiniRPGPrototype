using UnityEngine;

public class EnemyRewardSystem : MonoBehaviour, IRewardableCurrency
{

  private EnemyHealth enemyHealth;
  public float RewardCoins { get; set; }
  public GameEconomy gameEconomy;

  public void Init(float coins)
  {
    RewardCoins = coins;
  }
  void Awake()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    if (enemyHealth == null) return;

    enemyHealth.OnDeath += HandleDeathReward;
  }

  public void HandleDeathReward()
  {
    if (gameEconomy != null)
      gameEconomy.AddCurrency(RewardCoins);
  }

  void OnDisable()
  {
    enemyHealth.OnDeath -= HandleDeathReward;
  }
}