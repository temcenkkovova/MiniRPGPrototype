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
  public void SetItemDetails(ItemData item)
  {
    itemData = item;

    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    if (item is WeaponItem config)
    {
      WeaponItemDetail weaponItemDetail = Instantiate(prefab, gridParent);
      weaponItemDetail.Init(config);
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
}