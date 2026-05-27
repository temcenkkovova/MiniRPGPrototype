using UnityEngine;

public class EnemyRewardSystem : MonoBehaviour, IRewardableCurrency
{

  private EnemyHealth enemyHealth;
  public float RewardCurrency { get; set; }
  public GameEconomy gameEconomy;

  public void Init(float rewardAmount)
  {
    RewardCurrency = rewardAmount;
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
      gameEconomy.AddCurrency(RewardCurrency);
  }

  void OnDisable()
  {
    enemyHealth.OnDeath -= HandleDeathReward;
  }
}