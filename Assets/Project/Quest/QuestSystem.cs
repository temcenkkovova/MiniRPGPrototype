using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
  // here will be current quests to complete
  public List<QuestData> acceptedQuests = new List<QuestData>();
  public List<QuestData> completedQuests = new List<QuestData>();

  public event Action OnQuestsChanged;

  void Start()
  {
    GameEvents.OnEnemyKilled += QuestEnemyKilled;
  }

  void OnDisable()
  {
    GameEvents.OnEnemyKilled -= QuestEnemyKilled;
  }

  public void AcceptQuest(QuestConfig config, QuestManager questManager)
  {

    QuestData isExist = acceptedQuests.Find(item => item.Config.name == config.name);

    if (isExist != null)
    {
      questManager.CloseDialog();
      Debug.Log("YOu have accepted this quest");
      return;
    }
    else
    {
      QuestData questData = new QuestData
      {
        Config = config,
        CurrentKills = 0,
      };
      acceptedQuests.Add(questData);
      OnQuestsChanged?.Invoke();
      questManager.CloseDialog(); // I implemented it for make sure that the quest will accept than I will close the dialog
      questManager.ChangeQuestStatus();
    }
  }

  public void QuestEnemyKilled(string enemyName)
  {
    foreach (var quest in acceptedQuests)
    {
      if (quest.isCompleted)
        continue;

      if (quest.Config.EnemyNameToKill == enemyName)
      {
        quest.AddKill();
      }
    }
  }

  public void CompletedQuest(QuestConfig questConfig)
  {
    QuestData questData = acceptedQuests.Find(item => item.Config.name == questConfig.name);
    acceptedQuests.Remove(questData);
    completedQuests.Add(questData);
    OnQuestsChanged?.Invoke();
    if (questData == null) return;

    GameEvents.QuestCompleted(questData);
  }


}