using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
  private float damage;
  private Collider swordCollider;
  private Transform ownerTr;
  private bool hitStatus;
  private IDamageable currentTarget;
  private bool startAttack;

  private void Awake()
  {
    swordCollider = GetComponent<Collider>();
  }

  private void OnEnable()
  {
    DisableCollider();
  }

  public void SetDamage(float newDamage, Transform ownerTr)
  {
    damage = newDamage;
    this.ownerTr = ownerTr;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!startAttack) return;
    if (ownerTr == null) return;

    IDamageable damageable = other.GetComponent<IDamageable>();
    if (damageable == null) return;

    bool equalTag = ownerTr.CompareTag(other.tag);
    if (equalTag) return;

    if (hitStatus) return;

    hitStatus = true;
    currentTarget = damageable;

    damageable.TakeDamage(damage, ownerTr);
  }

  public void EnableCollider()
  {
    hitStatus = false;
    startAttack = true;
    currentTarget = null;

    if (swordCollider)
      swordCollider.enabled = true;
  }

  public void DisableCollider()
  {
    if (swordCollider)
      swordCollider.enabled = false;

    hitStatus = false;
    startAttack = false;
    currentTarget = null;
  }
}