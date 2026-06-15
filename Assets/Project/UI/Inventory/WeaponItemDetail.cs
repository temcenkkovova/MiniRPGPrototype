using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItemDetail : MonoBehaviour // For future I will make ConsumableItemDetail if I want to have heal or something else;
{

  public Image icon;
  public TMP_Text titleField;
  public TMP_Text damageField;
  public TMP_Text speedField;
  public TMP_Text radiusField;
  public Button equipBtn;
  public TMP_Text btnTextField;
  private WeaponItem weaponToEquip;
  public TMP_Text battlePowerField;
  private InventorySystem inventorySystem;
  private PlayerWeaponController playerWeaponController;



  public void Init(WeaponItem weaponItem, PlayerWeaponController playerWeapon, InventorySystem inventory)
  {

    inventorySystem = inventory;
    weaponToEquip = weaponItem;
    playerWeaponController = playerWeapon;
    icon.sprite = weaponItem.icon;
    titleField.text = weaponItem.title;
    damageField.text = "Damage - " + weaponItem.weaponConfig.damage.ToString();
    radiusField.text = "Range - " + weaponItem.weaponConfig.range.ToString();
    speedField.text = "Speed - " + weaponItem.weaponConfig.cooldown.ToString() + "s";
    battlePowerField.text = weaponItem.weaponConfig.startBP.ToString();

    equipBtn.interactable = !playerWeaponController.IsEquipped(weaponToEquip); ;
    if (playerWeaponController.IsEquipped(weaponToEquip))
    {
      btnTextField.text = "Equipped";

    }
  }

  public void HandleEquipClick()
  {
    if (playerWeaponController == null) return;
    playerWeaponController.EquipWeapon(weaponToEquip.weaponConfig, weaponToEquip);

    equipBtn.interactable = !playerWeaponController.IsEquipped(weaponToEquip);
    btnTextField.text = "Equipped";
  }
  public void HandleSellClick()
  {
    if (inventorySystem == null) return;
    if (playerWeaponController.IsEquipped(weaponToEquip)) return;
    inventorySystem.TrySellItem(weaponToEquip);
  }


}