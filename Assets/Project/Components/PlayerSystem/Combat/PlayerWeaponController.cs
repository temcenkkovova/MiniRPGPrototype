using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

  public WeaponConfig CurrentWeaponConfig { get; private set; }
  private MeleeAttack attack;
  [SerializeField] private WeaponConfig startWeapon;
  public Transform weaponPositionGrid;
  private WeaponStats weaponStats;
  public WeaponItem EquippedWeapon { get; private set; }

  void Awake()
  {
    attack = GetComponent<MeleeAttack>();
  }

  void Start()
  {
    EquipWeapon(startWeapon);
  }
  public void EquipWeapon(WeaponConfig newWeapon, WeaponItem weaponItem = null)
  {
    CurrentWeaponConfig = newWeapon;
    if (weaponItem)
      EquippedWeapon = weaponItem;
    weaponStats = new WeaponStats(CurrentWeaponConfig);
    foreach (Transform child in weaponPositionGrid)
      Destroy(child.gameObject);

    GameObject weapon = Instantiate(CurrentWeaponConfig.weaponPrefab, weaponPositionGrid);

    attack.InitWeaponHitBox(weapon.GetComponent<SwordHitBox>());
    attack.Init(weaponStats);
  }

  public bool IsEquipped(WeaponItem weaponItem)
  {
    return EquippedWeapon == weaponItem;
  }
}