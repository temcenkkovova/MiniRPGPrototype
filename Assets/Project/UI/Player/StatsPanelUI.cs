using TMPro;
using UnityEngine;

public class StatsPanelUI : MonoBehaviour
{
  public TMP_Text damageField;
  public TMP_Text healthField;
  public TMP_Text speedField;
  public TMP_Text armorField;
  public TMP_Text totalBattlePowerField;
  public TMP_Text weaponDamageField;
  public TMP_Text weaponBPField;

  public void InitStats(PlayerStats playerStats, WeaponStats weaponStats)
  {
    damageField.text = playerStats.BaseDamage.ToString();
    weaponDamageField.text = weaponStats.WeaponDamage.ToString();
    healthField.text = playerStats.Health.ToString();
    speedField.text = playerStats.MoveSpeed.ToString();
    armorField.text = "20";
    totalBattlePowerField.text = playerStats.PlayerPower.ToString();
    weaponBPField.text = weaponStats.CombatPower.ToString();

  }
}