using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
  public List<ItemData> inventoryItems;
  public event Action OnInventoryChanged;

  public void AddItem(ItemData item)
  {
    if (item is WeaponItem weaponItem)
    {
      inventoryItems.Add(weaponItem);
      OnInventoryChanged?.Invoke();
    }

    // if(item is AnotherType anotherType) // when I and one more type I can use this code example
    // {
    //   inventoryItems.Add(anotherType);
    //   OnInventoryChanged?.Invoke();
    // }


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