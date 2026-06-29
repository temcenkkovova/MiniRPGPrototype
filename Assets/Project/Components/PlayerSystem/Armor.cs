using UnityEngine;

public class Armor : MonoBehaviour
{
  private float armorValue = 0;

  public void InitArmor(float armorValue)
  {
    this.armorValue = armorValue;
  }

  public float ReduceDamage(float incomingDamage)
  {
    float modifyDamage = incomingDamage - armorValue;
    return Mathf.Max(modifyDamage, 1f);
  }
}