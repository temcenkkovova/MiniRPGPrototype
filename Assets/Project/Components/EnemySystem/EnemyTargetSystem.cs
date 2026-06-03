using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour
{
  private Transform targetTr;
  public Transform TargetTr => targetTr;
  private PlayerBootstrap player;
  private PlayerHealth playerHealth;

  public void SetNewTarget(DamageInfo damageInfo)
  {
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