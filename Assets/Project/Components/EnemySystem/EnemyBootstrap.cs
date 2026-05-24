using UnityEngine;

public class EnemyBootstrap : MonoBehaviour
{
  public EnemyConfig enemyConfig;

  private EnemyHealth enemyHealth;
  private EnemyFSMController fsmController;
  private ChaseState chaseState;
  public Transform playerTr;
  private EnemyMovement enemyMovement;

  void Awake()
  {
    InitComponents();
  }

  void Start()
  {
    if (enemyHealth == null || fsmController == null || enemyMovement == null) return;
    enemyHealth.Init(enemyConfig.maxHealth);
    enemyMovement.Init(enemyConfig);
    fsmController.InitState(enemyHealth);

    chaseState = new ChaseState(playerTr, enemyMovement);
  }

  private void InitComponents()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    fsmController = GetComponent<EnemyFSMController>();
    enemyMovement = GetComponent<EnemyMovement>();
  }

}