using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
  private float damage;
  private Collider swordCollider;
  private Transform ownerTr;
  void Awake()
  {
    swordCollider = GetComponent<Collider>();
  }
  void OnEnable()
  {
    DisableCollider();
  }

  public void SetDamage(float newDamage, Transform ownerTr)
  {
    damage = newDamage;
    this.ownerTr = ownerTr;

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<IDamageable>(out var damageable))
    {
      damageable.TakeDamage(damage, ownerTr);
    }

  }

  void OnTriggerExit(Collider other)
  {

  }
  public void EnableCollider()
  {

    if (swordCollider)
      swordCollider.enabled = true;
  }

  public void DisableCollider()
  {

    if (swordCollider)
      swordCollider.enabled = false;
  }
}