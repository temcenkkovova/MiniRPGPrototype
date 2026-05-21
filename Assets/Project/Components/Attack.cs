using Unity.VisualScripting;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{

  [SerializeField] protected AttackConfig attackConfig;

  protected float lastAttackTime;

  public void Init(AttackConfig config)
  {
    attackConfig = config;
  }

  public virtual bool CanAttack()
  {
    return Time.time >= lastAttackTime + attackConfig.cooldown;
  }

  public virtual void TryAttack()
  {
    if (!CanAttack()) return;
    ExecuteAttack();
    lastAttackTime = Time.time;
  }

  protected abstract void ExecuteAttack();
}