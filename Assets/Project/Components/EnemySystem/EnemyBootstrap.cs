using UnityEngine;

public class EnemyBootstrap : MonoBehaviour
{
  public EnemyConfig enemyConfig;

  private EnemyHealth enemyHealth;

  void Awake()
  {
    InitComponents();
  }

  void Start()
  {
    if (enemyHealth == null) return;
    enemyHealth.Init(enemyConfig.maxHealth);
  }

  private void InitComponents()
  {
    enemyHealth = GetComponent<EnemyHealth>();
  }

}