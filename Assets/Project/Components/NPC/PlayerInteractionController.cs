using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
  private NPCBootstrap currentNPC;
  private NPCInteraction npcInteraction;

  public void InitCurrentNPC(NPCBootstrap newNPC, NPCInteraction npcInteraction)
  {

    currentNPC = newNPC;
    this.npcInteraction = npcInteraction;
  }

  public void HandleInteract()
  {
    if (npcInteraction.InRadius)
      currentNPC?.Interact();
  }
}