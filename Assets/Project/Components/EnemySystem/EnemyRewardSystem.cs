using UnityEngine;

public class EnemyRewardSystem : MonoBehaviour
{

  private EnemyHealth enemyHealth;
  public float Currencies { get; private set; }
  public float Experience { get; private set; }
  private PlayerLevel playerLevel;

  public void InitPlayerRef(PlayerBootstrap player)
  {
    if (player)
      playerLevel = player.GetComponent<PlayerLevel>();
  }
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
    if (playerLevel == null) return;
    GameEconomy.Instance.AddCurrency(Currencies);
    playerLevel.AddExp(Experience);
  }

  void OnDisable()
  {
    enemyHealth.OnDeath -= HandleDeathReward;
  }
}