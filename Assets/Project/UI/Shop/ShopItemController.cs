using UnityEngine;
using UnityEngine.UI;

public class ShopItemController : MonoBehaviour
{

  public Button itemPanel;
  private PlayerTotalPower playerTotalPower;
  private int requiredBP;
  public Image iconItem;


  public void Init(ItemData item, PlayerTotalPower playerTP)
  {
    playerTotalPower = playerTP;
    if (playerTotalPower == null) return;
    if (item is WeaponItem weapon)
    {
      requiredBP = weapon.weaponConfig.startBP;
      BattlePowerChanged(playerTotalPower.BattlePower);
      playerTotalPower.OnBpChanged += BattlePowerChanged;
    }
  }

  private void BattlePowerChanged(int value)
  {
    bool active = requiredBP <= value;
    itemPanel.interactable = active;
    iconItem.color = active == true ? Color.white : Color.gray;

  }

  void OnDisable()
  {
    if (playerTotalPower == null) return;
    playerTotalPower.OnBpChanged -= BattlePowerChanged;
  }
}