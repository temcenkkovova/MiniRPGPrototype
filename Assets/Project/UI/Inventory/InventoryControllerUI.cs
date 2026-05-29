using UnityEngine;

public class InventoryControllerUI : MonoBehaviour
{
  public InventorySystem inventory;
  public Transform gridParent;
  public InventoryItem itemPrefab;
  public InventoryManagerUI inventoryManager;


  void Awake()
  {
    if (inventory == null || inventoryManager == null) return;
    inventory.OnInventoryChanged += RebuildUI;
    inventoryManager.OnInventoryOpened += RebuildUI;
  }

  public void RebuildUI()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);

    for (int i = 0; i < inventory.inventoryItems.Count; i++)
    {
      InventoryItem item = Instantiate(itemPrefab, gridParent);
      item.Init(inventory.inventoryItems[i]);
    }
  }

  void OnDisable()
  {
    if (inventory == null || inventoryManager == null) return;
    inventory.OnInventoryChanged -= RebuildUI;
    inventoryManager.OnInventoryOpened -= RebuildUI;
  }
}