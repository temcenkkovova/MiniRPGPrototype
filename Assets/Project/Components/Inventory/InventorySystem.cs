using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
  public List<ItemData> inventoryItems;
  public event Action OnInventoryChanged;

  public void AddItem(ItemData item)
  {
    inventoryItems.Add(item);
    OnInventoryChanged?.Invoke();
  }

  public void RemoveItem(ItemData item)
  {
    if (inventoryItems.Contains(item))
    {
      inventoryItems.Remove(item);
      OnInventoryChanged?.Invoke();
    }
  }
}