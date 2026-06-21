using System;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

  public WeaponConfig CurrentWeaponConfig { get; private set; }
  private MeleeAttack attack;
  [SerializeField] public WeaponItem startWeapon;
  public Transform weaponPositionGrid;
  [NonSerialized] public WeaponStats weaponStats;
  public WeaponItem EquippedWeapon { get; private set; }
  private PlayerAudio playerAudio;
  public event Action OnWeaponChanged;

  public InventorySystem inventorySystem;

  void Awake()
  {
    attack = GetComponent<MeleeAttack>();
    playerAudio = GetComponent<PlayerAudio>();

  }

  void Start()
  {
    EquipWeapon(startWeapon.weaponConfig, startWeapon);
    inventorySystem.AddItem(startWeapon);
  }


  public void EquipWeapon(WeaponConfig newWeapon, WeaponItem weaponItem = null)
  {

    CurrentWeaponConfig = newWeapon;
    if (weaponItem)
    {
      EquippedWeapon = weaponItem;

    }
    weaponStats = new WeaponStats(CurrentWeaponConfig);
    foreach (Transform child in weaponPositionGrid)
      Destroy(child.gameObject);

    GameObject weapon = Instantiate(CurrentWeaponConfig.weaponPrefab, weaponPositionGrid);

    attack.InitWeaponHitBox(weapon.GetComponent<SwordHitBox>());
    attack.Init(weaponStats);
    playerAudio.InitWeaponConfig(CurrentWeaponConfig.weaponAudioConfig);
    OnWeaponChanged?.Invoke();
  }

  public bool IsEquipped(WeaponItem weaponItem)
  {
    return EquippedWeapon == weaponItem;
  }
}