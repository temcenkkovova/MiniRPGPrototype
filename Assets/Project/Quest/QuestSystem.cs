using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
  // here will current quests to complete
  public List<QuestData> acceptedQuests = new List<QuestData>();
  public event Action OnQuestsChanged;

  public void AcceptQuest(QuestConfig quest)
  {
    QuestData questData = new QuestData
    {
      Config = quest,
      CurrentKills = 0,
    };
    acceptedQuests.Add(questData);
    OnQuestsChanged?.Invoke();
  }
}