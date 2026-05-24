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
    chaseState = new ChaseState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = enemyAttack, enemyMovement = enemyMovement }, fsmController);
    idleState = new IdleState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = enemyAttack, enemyMovement = enemyMovement }, fsmController);
    attackState = new AttackState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = enemyAttack, enemyMovement = enemyMovement }, fsmController);
    patrolState = new PatrolState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = enemyAttack, enemyMovement = enemyMovement }, fsmController, 10f);
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