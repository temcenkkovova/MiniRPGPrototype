using TMPro;
using UnityEngine;

public class StatsPanelUI : MonoBehaviour
{
  public TMP_Text damageField;
  public TMP_Text healthField;
  public TMP_Text speedField;
  public TMP_Text armorField;
  public TMP_Text totalBattlePowerField;

  public void InitStats(PlayerStats playerStats, WeaponStats weaponStats)
  {
    damageField.text = "Player " + playerStats.BaseDamage + "  /  " + "Weapon " + weaponStats.WeaponDamage;
    healthField.text = playerStats.Health.ToString();
    speedField.text = playerStats.MoveSpeed.ToString();
    armorField.text = "20";
    totalBattlePowerField.text = "Player " + playerStats.PlayerPower.ToString() + "  /  " + "Weapon " + weaponStats.CombatPower.ToString();

  }
}