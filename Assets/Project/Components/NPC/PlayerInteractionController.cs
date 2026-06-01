using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
  private NPCBootstrap currentNPC;

  public void InitCurrentNPC(NPCBootstrap newNPC)
  {

    currentNPC = newNPC;
  }

  public void HandleInteract()
  {
    currentNPC?.Interact();
  }
}