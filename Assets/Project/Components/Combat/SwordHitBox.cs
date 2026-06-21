using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
  private float damage;
  private Collider swordCollider;
  private Transform ownerTr;
  private bool hitStatus = false;
  private IDamageable currentTarget;
  private bool startAttack = false;
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
    startAttack = true;
  }

  void OnTriggerEnter(Collider other)
  {
    if (!startAttack) return;
    string ownerTag = ownerTr.tag;
    IDamageable damageable = other.GetComponent<IDamageable>();
    currentTarget = damageable;
    bool equalTag = ownerTag == other.tag;
    if (damageable != null && !equalTag && !hitStatus)
    {
      hitStatus = true;

      damageable.TakeDamage(damage, ownerTr);
    }

  }

  void OnTriggerExit(Collider other)
  {
    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable == null) return;
    if (currentTarget == damageable && hitStatus)
    {

      hitStatus = false;
      startAttack = false;
    }

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