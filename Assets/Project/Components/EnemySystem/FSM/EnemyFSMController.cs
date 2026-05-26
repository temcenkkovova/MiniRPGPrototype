using System.Collections;
using UnityEngine;

public class EnemyFSMController : MonoBehaviour
{
  private IEnemyState currentState;
  private EnemyHealth enemyHealth;
  private IEnemyState deathState;

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

  public void InitState(EnemyHealth enemyHealth, IEnemyState idleState, IEnemyState deathState)
  {
    this.enemyHealth = enemyHealth;
    this.enemyHealth.OnDeath += HandleEnemyDeath;
    this.deathState = deathState;
    SwitchState(idleState);
  }

  private void HandleEnemyDeath()
  {
    SwitchState(deathState);
  }

  void OnDestroy()
  {
    if (enemyHealth != null)
      enemyHealth.OnDeath -= HandleEnemyDeath;
  }

  public void StartDestroyCoroutine()
  {
    StartCoroutine(destroyCoroutine());
  }
  private IEnumerator destroyCoroutine()
  {
    yield return new WaitForSeconds(3f);
    Destroy(gameObject);
  }
}