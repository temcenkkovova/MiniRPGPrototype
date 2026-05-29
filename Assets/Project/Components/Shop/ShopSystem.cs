using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{

  public event Action OnItemsChanged;


  public List<ItemData> shopItems;


  void Start()
  {

  }

  public void AddItem(ItemData newItem)
  {
    OnItemsChanged?.Invoke();
  }

  public void RemoveItem(ItemData item)
  {
    OnItemsChanged?.Invoke();
  }

  public void BuyItem(ItemData item)
  {

  }
}