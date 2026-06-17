using System;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{
  public event Action OnInventoryOpened;
  public event Action OnInventoryClosed;
  public GameObject inventoryPanel;
  private bool isOpen = false;
  public bool IsOpen => isOpen;

  public void OpenInventory()
  {
    isOpen = true;
    inventoryPanel.SetActive(isOpen);
    OnInventoryOpened?.Invoke();
    GameStateController.Instance.SetState(GameState.Inventory);
  }

  public void CloseInventory()
  {
    isOpen = false;
    inventoryPanel.SetActive(isOpen);
    OnInventoryClosed?.Invoke();
    GameStateController.Instance.SetState(GameState.Gameplay);
  }

}