using System;
using UnityEngine;


public static class GameEvents
{
  public static event Action<string> OnEnemyKilled;
  public static event Action<QuestData> OnQuestCompleted;

  public static void EnemyKilled(string enemyName)
  {
    Debug.Log(enemyName);
    OnEnemyKilled?.Invoke(enemyName);
  }

  public static void QuestCompleted(QuestData questData)
  {
    OnQuestCompleted?.Invoke(questData);
  }
}