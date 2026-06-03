using System;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{

  private PlayerWeaponController playerWeapon;
  private PlayerCombat playerCombat;
  private int battlePower;
  public int BattlePower => battlePower;
  public event Action<int> OnBpChanged;

  void Awake()
  {
    playerWeapon = GetComponent<PlayerWeaponController>();
    playerCombat = GetComponent<PlayerCombat>();

    playerWeapon.OnWeaponChanged += SetBattlePower;

  }

  void Start()
  {
    if (playerCombat == null || playerWeapon == null) return;
    playerCombat.playerStats.OnStatsChanged += SetBattlePower;


  }

  public void SetBattlePower()
  {
    battlePower = Mathf.RoundToInt(
    playerCombat.playerStats.PlayerPower + playerWeapon.weaponStats.CombatPower);
    OnBpChanged?.Invoke(battlePower);
  }
}