using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
  public List<ItemData> inventoryItems;
  public List<ItemData> allPossibleItems;
  public event Action OnInventoryChanged;
  public event Action<ItemData> OnItemSold;
  public void AddItem(ItemData item)
  {
    if (item is WeaponItem weaponItem)
    {
      if (inventoryItems.Contains(weaponItem))
      {
        Debug.Log("You have this item already");
        return;
      }
      else
      {
        inventoryItems.Add(weaponItem);
        OnInventoryChanged?.Invoke();
      }

    }

    // if(item is AnotherType anotherType) // when I add another  type of items I will  use it 
    // {
    //   inventoryItems.Add(anotherType);
    //   OnInventoryChanged?.Invoke();
    // }
  }

  public void InitSaveItemsName(List<string> itemNames)
  {
    inventoryItems.Clear();

    foreach (string itemName in itemNames)
    {
      ItemData foundItem = allPossibleItems.Find(item => item.name == itemName);

      if (foundItem != null)
      {
        inventoryItems.Add(foundItem);
      }
      else
      {
        Debug.LogWarning($"Item not found: {itemName}");
      }
    }
  }

  public void TrySellItem(ItemData item)
  {
    if (inventoryItems.Contains(item))
      OnItemSold?.Invoke(item);

  }

  public void Sell(ItemData item)
  {

    inventoryItems.Remove(item);
    OnInventoryChanged?.Invoke();

  }
}