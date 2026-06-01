using System;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

  public float npcRadius = 1f;
  private SphereCollider npcCollider;
  private bool inRadius = false;
  public bool InRadius => inRadius;
  public event Action<bool> OnInteractRequested;



  void Awake()
  {
    npcCollider = GetComponent<SphereCollider>();
    npcCollider.radius = npcRadius;

  }

  void OnTriggerEnter(Collider other)
  {

    if (other.TryGetComponent<PlayerInteractionController>(out _))
    {
      PlayerInteractionController playerController = other.GetComponent<PlayerInteractionController>();
      inRadius = true;
      playerController.InitCurrentNPC(GetComponent<NPCBootstrap>(), this);
      OnInteractRequested?.Invoke(inRadius);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.TryGetComponent<PlayerInteractionController>(out _))
    {
      inRadius = false;
      OnInteractRequested?.Invoke(inRadius);

    }
  }
}