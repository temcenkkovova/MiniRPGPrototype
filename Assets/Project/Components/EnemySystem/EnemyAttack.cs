using System;
using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
  public AttackConfig attackConfig;
  public bool isAttack;
  public event Action OnAttack;

  public void TryAttack()
  {
    Debug.Log("attack");
    OnAttack?.Invoke();
  }
}