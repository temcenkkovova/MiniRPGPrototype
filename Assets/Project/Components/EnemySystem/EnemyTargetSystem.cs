using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour
{
  private Transform targetTr;
  public Transform TargetTr => targetTr;
  private PlayerBootstrap player;
  private PlayerHealth playerHealth;
  private EnemyHealth enemyHealth;

  void Awake()
  {
    enemyHealth = GetComponent<EnemyHealth>();

  }

  public void SetNewTarget(DamageInfo damageInfo)
  {
    if (damageInfo.attacker.tag != "Player") return;
    targetTr = damageInfo.attacker;
    player = damageInfo.attacker.GetComponent<PlayerBootstrap>();
    playerHealth = damageInfo.attacker.GetComponent<PlayerHealth>();

    if (player != null && playerHealth != null)
    {
      player.GetComponent<PlayerSafeZone>().OnSafeZone += EnteredSafeZone;
      playerHealth.OnDeath += RemoveTarget;
    }
  }

  public void RemoveTarget()
  {
    targetTr = null;

    if (enemyHealth == null) return;
    if (enemyHealth.CurrentHealth < enemyHealth.MaxHealth)
    {
      Debug.Log("qq");
      enemyHealth.ResetHealth();
    }
  }

  public void EnteredSafeZone(bool inSafeZone)
  {
    if (inSafeZone)
    {
      player.GetComponent<PlayerSafeZone>().OnSafeZone -= EnteredSafeZone;
      RemoveTarget();
    }
  }
}