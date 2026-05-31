using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
  public Image iconField;
  private ItemData itemData;
  private InventoryDetailsPanelUI inventoryDetailsPanel;
  private InventorySystem inventory;


  public void Init(ItemData item, InventoryDetailsPanelUI inventoryDetailsPanelUI, InventorySystem inventorySystem)
  {
    itemData = item;
    iconField.sprite = item.icon;
    inventoryDetailsPanel = inventoryDetailsPanelUI;
    inventory = inventorySystem;
  }

  public void HandleBuyClick()
  {
    if (inventoryDetailsPanel == null) return;
    inventoryDetailsPanel.SetItemDetails(itemData, inventory);
  }

}