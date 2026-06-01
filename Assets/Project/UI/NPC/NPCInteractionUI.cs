using UnityEngine;

public class NPCInteractionUI : MonoBehaviour
{
  public NPCInteraction nPCInteraction;
  public GameObject popupPanel;



  void Awake()
  {
    if (nPCInteraction == null) return;
    nPCInteraction.OnInteractRequested += ShowPopup;
  }

  public void ShowPopup(bool status)
  {
    popupPanel.SetActive(status);
  }

  void OnDisable()
  {
    if (nPCInteraction == null) return;
    nPCInteraction.OnInteractRequested -= ShowPopup;
  }
}