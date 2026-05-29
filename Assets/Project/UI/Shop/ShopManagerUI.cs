using UnityEngine;

public class ShopManagerUI : MonoBehaviour
{
  public ShopSystem shopSystem;
  public Transform shopGridUI;
  public ShopItem prefabItem;
  public ShopUIController shopUIController;



  void Awake()
  {
    if (shopUIController == null) return;
    shopUIController.OnShopOpen += ShowItems;
  }


  public void ShowItems(bool isOpen)
  {
    if (isOpen)
    {
      foreach (Transform child in shopGridUI)
        Destroy(child.gameObject);
    }

    for (int i = 0; i < shopSystem.shopItems.Count; i++)
    {
      ShopItem item = Instantiate(prefabItem, shopGridUI);
      item.Init(shopSystem.shopItems[i]);
    }

  }

  void OnDisable()
  {
    if (shopUIController == null) return;
    shopUIController.OnShopOpen -= ShowItems;
  }
}