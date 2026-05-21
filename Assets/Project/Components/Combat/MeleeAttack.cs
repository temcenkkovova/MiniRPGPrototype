using UnityEngine;

public class MeleeAttack : Attack
{
  private PlayerCombat playerCombat;

  void Awake()
  {
    playerCombat = GetComponent<PlayerCombat>();
  }
  void Start()
  {

    ExecuteAttack();
  }

  protected override void ExecuteAttack()
  {
    if (playerCombat == null) return;

    float totalDamage = playerCombat.PlayerDamage + attackConfig.damage;

  }

}