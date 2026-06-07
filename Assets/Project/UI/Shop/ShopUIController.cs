using System;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{

  private bool shopStatus;
  public GameObject shopPanel;

  public event Action<bool> OnShopOpen;


  void Start()
  {

  }
  // Shop can be open by pressing button  if you close to NPC
  public void OpenShop()
  {
    if (shopPanel == null) return;
    shopPanel.SetActive(true);
    shopStatus = true;
    OnShopOpen?.Invoke(shopStatus);
    GameStateController.Instance.SetState(GameState.Shop);
  }

  public void CloseShop()
  {
    if (shopPanel == null) return;
    shopPanel.SetActive(false);
    shopStatus = false;
    OnShopOpen?.Invoke(shopStatus);
    GameStateController.Instance.SetState(GameState.Gameplay);
  }
}