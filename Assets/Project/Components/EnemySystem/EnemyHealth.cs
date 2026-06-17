using System;
using UnityEngine;

public class EnemyHealth : Health
{
  // public event Action<Transform> OnDamaged;
  public float HealthPercent => MaxHealth / CurrentHealth;
  private PopupManager popupManager;


  void Start()
  {
    ScaleHealth(EnemyManager.Instance.ScalingValue());
    OnDamaged += ShowPopUpHealth;
  }
  public void ShowPopUpHealth(DamageInfo damageInfo)
  {
    string context = "- " + damageInfo.Damage.ToString();
    popupManager.Show(context, transform, Color.red);
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