using UnityEngine;

public class InventoryControllerUI : MonoBehaviour
{
  public InventorySystem inventory;
  public Transform gridParent;
  public InventoryItem itemPrefab;
  public InventoryManagerUI inventoryManager;
  public InventoryDetailsPanelUI inventoryDetailsPanelUI;


  void Awake()
  {
    if (inventory == null || inventoryManager == null) return;
    inventory.OnInventoryChanged += RebuildUI;
    inventoryManager.OnInventoryOpened += RebuildUI;
    inventoryManager.OnInventoryClosed += HandleCloseInventory;
  }

  public void RebuildUI()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);

    for (int i = 0; i < inventory.inventoryItems.Count; i++)
    {
      InventoryItem item = Instantiate(itemPrefab, gridParent);
      item.Init(inventory.inventoryItems[i], inventoryDetailsPanelUI);
    }
  }

  public void HandleCloseInventory()
  {
    inventoryDetailsPanelUI.ClearDetailsPanel();
  }

  void OnDisable()
  {
    if (inventory == null || inventoryManager == null) return;
    inventory.OnInventoryChanged -= RebuildUI;
    inventoryManager.OnInventoryClosed -= HandleCloseInventory;
    inventoryManager.OnInventoryOpened -= RebuildUI;
  }
}