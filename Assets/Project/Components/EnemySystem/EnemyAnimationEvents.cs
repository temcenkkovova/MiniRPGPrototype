using System;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
  public event Action AttackAnimationFinished;
  public event Action AttackAnimationStarted;
  public void OnAttackAnimationStarted()
  {

    AttackAnimationStarted?.Invoke();
  }
  public void OnAttackAnimationFinished()
  {

    AttackAnimationFinished?.Invoke();
  }
}