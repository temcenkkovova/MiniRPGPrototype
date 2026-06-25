using System;

public class QuestData
{
  public QuestConfig Config;
  public int CurrentKills;
  public bool isCompleted => CurrentKills >= Config.RequiredKills;
  public event Action<int> OnCurrentKillsChanged;
}