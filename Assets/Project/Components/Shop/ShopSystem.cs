using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{

  public event Action OnItemsChanged;


  public List<ItemData> shopItems;
  public GameEconomy gameEconomy;
  public event Action<ItemData> OnItemPurchased;
  public InventorySystem inventory;
  public PlayerSafeZone safeZone;

  void Start()
  {

  }

  public void RefreshShop()
  {
    /*I need this method for refresh shop after load scene from SaveSystem*/
    RemoveOwnedItemsFromShop();
  }

  private void RemoveOwnedItemsFromShop()
  {
    shopItems.RemoveAll(shopItem => inventory.inventoryItems.Exists(inventoryItem => inventoryItem.name == shopItem.name)); // Here I delete from shop that I have in inventory; 
    // Find items by ID - better way . But I don`t have yet it;
    OnItemsChanged?.Invoke();
  }

  public void AddItem(ItemData newItem) // I will need this methods in future , when I have upgrade weapon by hero  power
  {
    shopItems.Add(newItem);
    OnItemsChanged?.Invoke();
  }

  public void RemoveItem(ItemData item) // I will need this methods in  future , when I have craft
  {
    if (shopItems.Contains(item))
    {
      shopItems.Remove(item);
      OnItemsChanged?.Invoke();
    }

  }

  public void BuyItem(ItemData item)
  {
    if (shopItems.Contains(item))
    {
      if (!gameEconomy.HasEnough(item.price)) return;
      gameEconomy.SpendCurrency(item.price);
      inventory.AddItem(item);
      RemoveItem(item);
      OnItemPurchased?.Invoke(item);
    }
  }
}