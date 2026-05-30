using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
  public Image iconField;
  private ItemData itemData;
  private InventoryDetailsPanelUI inventoryDetailsPanel;


  public void Init(ItemData item, InventoryDetailsPanelUI inventoryDetailsPanelUI)
  {
    itemData = item;
    iconField.sprite = item.icon;
    inventoryDetailsPanel = inventoryDetailsPanelUI;
  }

  public void HandleBuyClick()
  {
    if (inventoryDetailsPanel == null) return;
    inventoryDetailsPanel.SetItemDetails(itemData);
  }

}