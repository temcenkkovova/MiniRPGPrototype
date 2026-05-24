using System;
using UnityEngine;

public class PlayerSafeZone : MonoBehaviour
{
  private bool safeZoneStatus;
  public bool InSafeZone => safeZoneStatus;
  public event Action<bool> OnSafeZone;

  void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<ISafeZone>(out var safeZone))
    {
      safeZoneStatus = true;
      OnSafeZone?.Invoke(safeZoneStatus);
      Debug.Log("Is safe zone");
    }

  }

  void OnTriggerExit(Collider other)
  {
    if (other.TryGetComponent<ISafeZone>(out var safeZone))
    {
      safeZoneStatus = false;
      OnSafeZone?.Invoke(safeZoneStatus);
      Debug.Log("Leave  safe zone");
    }
  }
}