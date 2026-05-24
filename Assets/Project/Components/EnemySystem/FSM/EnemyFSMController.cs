using UnityEngine;

public class EnemyFSMController : MonoBehaviour
{
  private IEnemyState currentState;
  private EnemyHealth enemyHealth;

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

  public void InitState(EnemyHealth enemyHealth, IEnemyState idleState)
  {
    this.enemyHealth = enemyHealth;
    SwitchState(idleState);
  }
}