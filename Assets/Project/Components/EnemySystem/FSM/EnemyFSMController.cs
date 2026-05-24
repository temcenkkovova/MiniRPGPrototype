using UnityEngine;

public class EnemyFSMController : MonoBehaviour
{
  private IEnemyState currentState;
  private EnemyHealth enemyHealth;

  void Awake()
  {

    if (enemyHealth == null) return; // it needs to handle death state for future.

  }

  void Update()
  {
    currentState?.Update();
  }

  public void SwitchState(IEnemyState newState)
  {
    currentState?.Exit();
    currentState = newState;
    currentState?.Enter();
  }

  public void InitState(EnemyHealth enemyHealth)
  {
    this.enemyHealth = enemyHealth;
    //SwitchState()
  }
}