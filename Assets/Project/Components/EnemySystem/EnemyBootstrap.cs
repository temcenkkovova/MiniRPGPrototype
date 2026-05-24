using UnityEngine;

public class EnemyBootstrap : MonoBehaviour
{
  public EnemyConfig enemyConfig;

  private EnemyHealth enemyHealth;
  private EnemyFSMController fsmController;
  private ChaseState chaseState;
  private IdleState idleState;
  public IdleState IdleSt => idleState;
  public ChaseState ChaseSt => chaseState;
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyMovement enemyMovement;


  void Awake()
  {
    InitComponents();
  }

  void Start()
  {
    if (enemyHealth == null || fsmController == null || enemyMovement == null || enemyTargetSystem == null) return;
    enemyHealth.Init(enemyConfig.maxHealth);
    enemyMovement.Init(enemyConfig);
    fsmController.InitState(enemyHealth, IdleSt);
    enemyHealth.OnDamaged += enemyTargetSystem.SetNewTarget;
    chaseState = new ChaseState(enemyTargetSystem.TargetTr, enemyMovement);
    idleState = new IdleState(10, enemyTargetSystem, fsmController, this);
  }

  private void InitComponents()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    fsmController = GetComponent<EnemyFSMController>();
    enemyMovement = GetComponent<EnemyMovement>();
    enemyTargetSystem = GetComponent<EnemyTargetSystem>();
  }

}