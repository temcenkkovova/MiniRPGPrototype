using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
  private float damage;
  private Collider swordCollider;
  void Awake()
  {
    swordCollider = GetComponent<Collider>();
  }
  void OnEnable()
  {
    DisableCollider();
  }

  public void SetDamage(float newDamage)
  {
    damage = newDamage;

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<IDamageable>(out var damageable))
    {
      damageable.TakeDamage(damage);
    }

  }

  void OnTriggerExit(Collider other)
  {

  }
  public void EnableCollider()
  {
    swordCollider.enabled = true;
  }

  public void DisableCollider()
  {
    swordCollider.enabled = false;
  }
}