using UnityEngine;


public class PlayerHealth : Health
{
  public bool IsDead { get; private set; }

  void OnEnable()
  {
    IsDead = false;
  }
  protected override void Die()
  {
    base.Die();
    IsDead = true;
  }


}