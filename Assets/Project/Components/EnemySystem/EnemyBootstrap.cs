using UnityEngine;

public class EnemyBootstrap : MonoBehaviour
{
  public EnemyConfig enemyConfig;

  private EnemyHealth enemyHealth;
  private EnemyFSMController fsmController;
  private ChaseState chaseState;
  private IdleState idleState;
  private AttackState attackState;
  public IdleState IdleSt => idleState;
  public ChaseState ChaseSt => chaseState;
  public ChaseState AttackSt => chaseState;
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyMovement enemyMovement;
  private EnemyAttack enemyAttack;


  void Awake()
  {
    InitComponents();
  }

  void Start()
  {
    if (enemyHealth == null || fsmController == null || enemyMovement == null || enemyTargetSystem == null || enemyAttack == null) return;
    chaseState = new ChaseState(enemyTargetSystem, enemyMovement, fsmController, this, enemyAttack);
    idleState = new IdleState(10, enemyTargetSystem, fsmController, this);
    attackState = new AttackState(enemyTargetSystem, fsmController, this, enemyAttack);
    enemyHealth.Init(enemyConfig.maxHealth);
    enemyMovement.Init(enemyConfig);
    fsmController.InitState(enemyHealth, IdleSt);
    enemyHealth.OnDamaged += enemyTargetSystem.SetNewTarget;
  }

  private void InitComponents()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    fsmController = GetComponent<EnemyFSMController>();
    enemyMovement = GetComponent<EnemyMovement>();
    enemyTargetSystem = GetComponent<EnemyTargetSystem>();
    enemyAttack = GetComponent<EnemyAttack>();
  }

}