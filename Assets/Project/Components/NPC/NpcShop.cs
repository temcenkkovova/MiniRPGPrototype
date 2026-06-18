using UnityEngine;

public class NpcShop : MonoBehaviour
{
  public ShopUIController shopUIController;

  public void HandleOpenShop()
  {
    if (shopUIController != null)
      shopUIController.OpenShop();
  }
  public void HandleCloseShop()
  {
    if (shopUIController != null)
      shopUIController.CloseShop();
  }
  public bool ShopStatus()
  {
    return shopUIController.ShopStatus;
  }


}