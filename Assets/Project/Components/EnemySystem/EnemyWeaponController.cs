using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
  public WeaponConfig startWeaponConfig;
  public WeaponConfig CurrentWeaponConfig { get; private set; }
  public Transform weaponPositionGrid;

  private MeleeAttack attack;
  void Awake()
  {
    attack = GetComponent<MeleeAttack>();

  }
  void Start()
  {
    EquipWeapon(startWeaponConfig);
  }

  public void EquipWeapon(WeaponConfig newWeapon)
  {
    CurrentWeaponConfig = newWeapon;
    foreach (Transform child in weaponPositionGrid)
      Destroy(child.gameObject);

    GameObject weapon = Instantiate(CurrentWeaponConfig.weaponPrefab, weaponPositionGrid);

    attack.InitWeaponHitBox(weapon.GetComponent<SwordHitBox>());
    attack.Init(CurrentWeaponConfig);
  }
}