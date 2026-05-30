using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

  public WeaponConfig CurrentWeaponConfig { get; private set; }
  private MeleeAttack attack;
  [SerializeField] private WeaponConfig startWeapon;
  public Transform weaponPositionGrid;

  void Awake()
  {
    attack = GetComponent<MeleeAttack>();
  }

  void Start()
  {
    EquipWeapon(startWeapon);
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