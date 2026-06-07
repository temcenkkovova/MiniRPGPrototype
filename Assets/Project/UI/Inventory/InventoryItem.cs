using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
  public Image iconField;
  private ItemData itemData;
  private InventoryDetailsPanelUI inventoryDetailsPanel;
  private InventorySystem inventory;
  private PlayerWeaponController playerWeapon;
  private WeaponItem weapon;


  public void Init(ItemData item, InventoryDetailsPanelUI inventoryDetailsPanelUI, InventorySystem inventorySystem, PlayerWeaponController playerWeaponController)
  {
    playerWeapon = playerWeaponController;
    itemData = item;
    iconField.sprite = item.icon;
    inventoryDetailsPanel = inventoryDetailsPanelUI;
    inventory = inventorySystem;
    if (item is WeaponItem weaponItem)
    {
      weapon = weaponItem;
    }
    ;
    Refresh();
    if (playerWeapon == null) return;
    playerWeapon.OnWeaponChanged += Refresh;
  }

  public void HandleBuyClick()
  {
    if (inventoryDetailsPanel == null) return;
    inventoryDetailsPanel.SetItemDetails(itemData, inventory);
  }

  public void Refresh()
  {
    if (weapon == null) return;
    bool equipped = playerWeapon.IsEquipped(weapon);
    if (iconField)
      iconField.color =
            equipped
                ? Color.gray
                : Color.white;
  }

  void OnEnable()
  {

  }
  void OnDisable()
  {
    if (playerWeapon == null) return;
    playerWeapon.OnWeaponChanged -= Refresh;
  }
}