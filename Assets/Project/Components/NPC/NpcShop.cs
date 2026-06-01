using UnityEngine;

public class NpcShop : MonoBehaviour
{
  public ShopUIController shopUIController;

  public void HandleOpenShop()
  {
    if (shopUIController != null)
      shopUIController.OpenShop();
  }
}