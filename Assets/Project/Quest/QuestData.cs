using System;

public class QuestData
{
  public QuestConfig Config;
  public int CurrentKills;
  public bool isCompleted => CurrentKills >= Config.RequiredKills;
  public event Action<int> OnCurrentKillsChanged;
  public event Action<QuestData> OnQuestCompleted;


  public void AddKill()
  {
    if (isCompleted) return;

    CurrentKills++;
    OnCurrentKillsChanged.Invoke(CurrentKills);
    if (isCompleted)
    {
      OnQuestCompleted.Invoke(this);
    }

  }
}