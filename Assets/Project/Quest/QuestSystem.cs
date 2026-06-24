using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
  // here will current quests to complete
  public List<QuestData> acceptedQuests = new List<QuestData>();
  public event Action OnQuestsChanged;

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
    }
  }
}