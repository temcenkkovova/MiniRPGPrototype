using UnityEngine;
[CreateAssetMenu(menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
  public float maxHealth;
  public float moveSpeed;
  public float baseArmor;
  public float expToNextLevel;
  public float multiplyExp;
  public float baseDamage;
  public float sprintSpeed;

}