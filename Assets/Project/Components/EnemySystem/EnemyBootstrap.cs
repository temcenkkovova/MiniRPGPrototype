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
  private DeadState deadState;
  public IdleState IdleSt => idleState;
  public ChaseState ChaseSt => chaseState;
  public AttackState AttackSt => attackState;
  public PatrolState PatrolSt => patrolState;
  public DeadState DeadSt => deadState;
  private EnemyTargetSystem enemyTargetSystem;
  private EnemyMovement enemyMovement;
  private Attack attack;
  private EnemyAnimationsController enemyAnimationController;
  private EnemyAttackManager enemyAttackManager;

  void Awake()
  {
    InitComponents();
  }

  void Start()
  {
    if (enemyHealth == null || fsmController == null || enemyMovement == null || enemyTargetSystem == null || attack == null || enemyAnimationController == null || enemyAttackManager == null) return;
    chaseState = new ChaseState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = attack, enemyMovement = enemyMovement }, fsmController, enemyAttackManager);
    idleState = new IdleState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = attack, enemyMovement = enemyMovement }, fsmController);
    attackState = new AttackState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = attack, enemyMovement = enemyMovement }, fsmController, enemyAttackManager);
    patrolState = new PatrolState(new EnemyContext { enemyTargetSystem = enemyTargetSystem, enemy = this, enemyAttack = attack, enemyMovement = enemyMovement }, fsmController, 10f);
    deadState = new DeadState(fsmController, enemyAnimationController);

    enemyHealth.Init(enemyConfig.maxHealth);
    enemyMovement.Init(enemyConfig);
    fsmController.InitState(enemyHealth, IdleSt, DeadSt);
    enemyHealth.OnDamaged += enemyTargetSystem.SetNewTarget;

  }

  private void InitComponents()
  {
    enemyHealth = GetComponent<EnemyHealth>();
    fsmController = GetComponent<EnemyFSMController>();
    enemyMovement = GetComponent<EnemyMovement>();
    enemyTargetSystem = GetComponent<EnemyTargetSystem>();
    attack = GetComponent<Attack>();
    enemyAnimationController = GetComponent<EnemyAnimationsController>();
    enemyAttackManager = GetComponent<EnemyAttackManager>();
  }

  void OnDisable()
  {
    if (enemyHealth != null && attack != null)
    {
      enemyHealth.OnDamaged -= enemyTargetSystem.SetNewTarget;
    }

  }
}