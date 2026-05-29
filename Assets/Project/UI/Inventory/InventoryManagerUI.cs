using System;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{
  public event Action OnInventoryOpened;
  public GameObject inventoryPanel;
  private bool isOpen = false;

  public void OpenInventory()
  {
    isOpen = true;
    inventoryPanel.SetActive(isOpen);
    OnInventoryOpened?.Invoke();
  }

  public void CloseInventory()
  {
    isOpen = false;
    inventoryPanel.SetActive(isOpen);
    OnInventoryOpened?.Invoke();
  }

}