using System;
using UnityEngine;

public class EnemyHealth : Health
{
  // public event Action<Transform> OnDamaged;
  public float HealthPercent => MaxHealth / CurrentHealth;
  private PopupManager popupManager;
  private Transform currentTr;


  void Start()
  {
    ScaleHealth(EnemyManager.Instance.ScalingValue());
    OnDamaged += ShowPopUpHealth;
    currentTr = transform;
  }
  public void ShowPopUpHealth(DamageInfo damageInfo)
  {
    string context = "- " + damageInfo.Damage.ToString();
    popupManager.Show(context, currentTr, Color.red);
  }

  protected override void Die()
  {
    base.Die();
  }

  void OnDestroy()
  {

    OnDamaged -= ShowPopUpHealth;
  }

  public void InitPopupManager(PopupManager manager)
  {
    popupManager = manager;
  }

}