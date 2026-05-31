using System;
using UnityEngine;

public class InventoryDetailsPanelUI : MonoBehaviour
{

  private ItemData itemData;
  public Transform gridParent;

  public GameObject detailsPanel;
  public WeaponItemDetail prefab;
  //public ConsumableItemDetail consumePrefab; // for future
  private bool isOpenPanel = false;
  public event Action<bool> OnOpenDetailPanel;
  public PlayerWeaponController playerWeaponController;
  private InventorySystem inventorySystem;
  public void SetItemDetails(ItemData item, InventorySystem inventory)
  {
    inventorySystem = inventory;
    if (inventorySystem != null)
      inventorySystem.OnInventoryChanged += ClearDetailsPanel;
    itemData = item;
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    if (item is WeaponItem config)
    {
      WeaponItemDetail weaponItemDetail = Instantiate(prefab, gridParent);
      weaponItemDetail.Init(config, playerWeaponController, inventorySystem);
    }
    // I can add another type of Item 

    OpenDetailsPanel();
  }

  public void OpenDetailsPanel()
  {
    isOpenPanel = true;
    detailsPanel.SetActive(isOpenPanel);
    OnOpenDetailPanel?.Invoke(isOpenPanel);
  }
  public void ClearDetailsPanel()
  {
    isOpenPanel = false;
    detailsPanel.SetActive(isOpenPanel);
    OnOpenDetailPanel?.Invoke(isOpenPanel);
  }

  void OnDisable()
  {
    if (inventorySystem != null)
      inventorySystem.OnInventoryChanged -= ClearDetailsPanel;
  }
}