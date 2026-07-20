using UnityEngine;

public interface IDamageable
{
  public void TakeDamage(float damage, Transform attacker, Vector3 hitPoint);

}