using System;
using UnityEngine;


public static class GameEvents
{
  public static event Action<string> OnEnemyKilled;
  public static event Action<RewardData> OnQuestCompleted;

  public static void EnemyKilled(string enemyName)
  {
    Debug.Log(enemyName);
    OnEnemyKilled?.Invoke(enemyName);
  }

  public static void QuestCompleted(QuestData questData)
  {
    RewardData reward = new RewardData
    {
      Coins = questData.Config.rewardCoins,
      Exp = questData.Config.RewardExp,
    };
    OnQuestCompleted?.Invoke(reward);
  }
}