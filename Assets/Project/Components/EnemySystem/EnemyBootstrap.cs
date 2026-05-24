using UnityEngine;

public class EnemyBootstrap : MonoBehaviour
{
  public EnemyConfig enemyConfig;

  private EnemyHealth enemyHealth;
  private EnemyFSMController fsmController;
  private ChaseState chaseState;
  private IdleState idleState;
  private AttackState attackState;
  private PatrolState patrolState;
  public IdleState IdleSt => idleState;
  public ChaseState ChaseSt => chaseState;
  public AttackState AttackSt => attackState;
  public PatrolState PatrolSt => patrolState;
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
    idleState = new IdleState(enemyTargetSystem, fsmController, this);
    attackState = new AttackState(enemyTargetSystem, fsmController, this, enemyAttack);
    patrolState = new PatrolState(10f, enemyTargetSystem, fsmController, this, enemyMovement);
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