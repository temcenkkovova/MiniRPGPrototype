using System;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{

  private bool shopStatus;
  public GameObject shopPanel;

  public event Action<bool> OnShopOpen;

  void Start()
  {
    // OpenShop();// temporary code;  
  }

  public void OpenShop()
  {
    if (shopPanel == null) return;
    shopPanel.SetActive(true);
    shopStatus = true;
    OnShopOpen?.Invoke(shopStatus);
  }

  public void CloseShop()
  {
    if (shopPanel == null) return;
    shopPanel.SetActive(false);
    shopStatus = false;
    OnShopOpen?.Invoke(shopStatus);
  }
}