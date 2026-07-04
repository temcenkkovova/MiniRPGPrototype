using System;
using UnityEngine;

public class EnemyHealth : Health
{
  // public event Action<Transform> OnDamaged;
  public float HealthPercent => MaxHealth / CurrentHealth;
  private PopupManager popupManager;
  private Transform currentTr;

  private EnemyConfig enemyConfig;

  private Collider enemyCollider;

  void Start()
  {
    ScaleHealth(EnemyManager.Instance.ScalingValue());
    OnDamaged += ShowPopUpHealth;
    currentTr = transform;

    enemyCollider = GetComponent<Collider>();
  }
  public void ShowPopUpHealth(DamageInfo damageInfo)
  {
    string context = "- " + damageInfo.Damage.ToString("F0");
    popupManager.Show(context, currentTr, Color.red);
  }

  protected override void Die()
  {
    base.Die();
    enemyCollider.enabled = false;
    GameEvents.EnemyKilled(enemyConfig.name);
  }

  void OnDestroy()
  {

    OnDamaged -= ShowPopUpHealth;
  }

  public void InitEnemyConfig(EnemyConfig enemyConfig)
  {
    this.enemyConfig = enemyConfig;
  }

  public void InitPopupManager(PopupManager manager)
  {
    popupManager = manager;

  }

}