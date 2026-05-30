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

  public void Init(WeaponItem weaponItem)
  {
    icon.sprite = weaponItem.icon;
    titleField.text = weaponItem.title;
    damageField.text = weaponItem.weaponConfig.damage.ToString();
    radiusField.text = weaponItem.weaponConfig.range.ToString();
    speedField.text = weaponItem.weaponConfig.cooldown.ToString() + "s";
  }
}