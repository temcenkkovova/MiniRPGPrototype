using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour
{
  private Transform targetTr;
  public Transform TargetTr => targetTr;
  private PlayerBootstrap player;

  public void SetNewTarget(DamageInfo damageInfo)
  {
    targetTr = damageInfo.attacker;
    player = damageInfo.attacker.GetComponent<PlayerBootstrap>();

    if (player != null)
    {
      player.GetComponent<PlayerSafeZone>().OnSafeZone += RemoveTarget;
    }
  }

  public void RemoveTarget(bool newSafeZoneStatus)
  {

    if (newSafeZoneStatus)
      player.GetComponent<PlayerSafeZone>().OnSafeZone -= RemoveTarget;

    targetTr = null;
  }
}