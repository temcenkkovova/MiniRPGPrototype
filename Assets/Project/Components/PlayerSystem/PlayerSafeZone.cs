using System;
using UnityEngine;

public class PlayerSafeZone : MonoBehaviour
{
  private bool safeZoneStatus = false;
  public bool InSafeZone => safeZoneStatus;
  public event Action<bool> OnSafeZone;

  void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<ISafeZone>(out var safeZone))
    {
      safeZoneStatus = true;
      OnSafeZone?.Invoke(safeZoneStatus);

    }

  }

  void OnTriggerExit(Collider other)
  {
    if (other.TryGetComponent<ISafeZone>(out var safeZone))
    {
      safeZoneStatus = false;
      OnSafeZone?.Invoke(safeZoneStatus);

    }
  }
}