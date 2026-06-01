using System;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

  public float npcRadius = 1f;
  private SphereCollider npcCollider;
  private bool inRadius = false;
  public event Action<bool> OnRadiusEntered;



  void Awake()
  {
    npcCollider = GetComponent<SphereCollider>();
    npcCollider.radius = npcRadius;

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<PlayerBootstrap>(out _))
    {
      inRadius = true;
      OnRadiusEntered?.Invoke(inRadius);

    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.TryGetComponent<PlayerBootstrap>(out _))
    {
      inRadius = false;
      OnRadiusEntered?.Invoke(inRadius);

    }
  }

}