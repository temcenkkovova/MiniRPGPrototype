using System;
using UnityEngine;

public class PlayerTotalPower : MonoBehaviour
{

  [NonSerialized] public PlayerWeaponController playerWeapon;
  [NonSerialized] public PlayerCombat playerCombat;
  private int battlePower;
  public int BattlePower => battlePower;
  public event Action<int> OnBpChanged;

  void Awake()
  {
    playerWeapon = GetComponent<PlayerWeaponController>();
    playerCombat = GetComponent<PlayerCombat>();

    playerWeapon.OnWeaponChanged += SetTotalPower;

  }

  void Start()
  {
    if (playerCombat == null || playerWeapon == null) return;
    playerCombat.playerStats.OnStatsChanged += SetTotalPower;
  }

  public void SetTotalPower()
  {
    battlePower = Mathf.RoundToInt(
    playerCombat.playerStats.PlayerPower + playerWeapon.weaponStats.CombatPower);

    OnBpChanged?.Invoke(battlePower);
  }
}