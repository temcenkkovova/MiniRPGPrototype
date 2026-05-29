using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
  public List<ItemData> inventoryItems;

  public void AddItem(ItemData item)
  {
    inventoryItems.Add(item);
  }
}