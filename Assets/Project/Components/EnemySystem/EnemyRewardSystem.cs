using UnityEngine;

public class EnemyRewardSystem : MonoBehaviour
{

  private EnemyHealth enemyHealth;
  public float Currencies { get; private set; }
  public float Experience { get; private set; }
  public GameEconomy gameEconomy;
  public PlayerLevel playerLevel;

  public void Init(float coins, float expReward)
  {
    Currencies = coins;
    Experience = expReward;
  }
  void Awake()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    if (enemyHealth == null) return;

    enemyHealth.OnDeath += HandleDeathReward;
  }

  public void HandleDeathReward()
  {
    if (gameEconomy == null || playerLevel == null) return;
    gameEconomy.AddCurrency(Currencies);
    playerLevel.AddExp(Experience);
  }

  void OnDisable()
  {
    enemyHealth.OnDeath -= HandleDeathReward;
  }
}