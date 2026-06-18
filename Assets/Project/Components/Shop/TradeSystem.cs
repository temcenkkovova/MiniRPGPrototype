using UnityEngine;

public class TradeSystem : MonoBehaviour
{
  public InventorySystem inventorySystem;
  public ShopSystem shopSystem;
  public GameEconomy gameEconomy;

  void Awake()
  {
    if (shopSystem == null || inventorySystem == null) return;
    inventorySystem.OnItemSold += HandleItemSold;
  }

  public void HandleItemSold(ItemData item)
  {
    inventorySystem.Sell(item);
    gameEconomy.AddCurrency(item.price); // I need to calculate average price for future
    if (shopSystem.shopItems.Contains(item)) return;
    shopSystem.AddItem(item);
  }
}