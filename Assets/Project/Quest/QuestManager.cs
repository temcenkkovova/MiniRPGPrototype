using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  public QuestConfig config;
  public QuestSystem questSystem;
  public List<QuestConfig> configs;
  private bool isAcceptedQuest = false;
  public bool IsAcceptedQuest => isAcceptedQuest;

  public event Action<bool> IsOpenQuestDialog;
  private int currentQuestNumber = 0;

  public QuestConfig currentQuestConfig => configs[currentQuestNumber];

  public bool CheckQuestCompleteStatus()
  {
    bool status = false;

    QuestData questData = questSystem.acceptedQuests.Find(item => item.Config.name == currentQuestConfig.name);
    if (questData == null) return false;
    status = questData.isCompleted;
    return status;
  }

  public void OpenDialog()
  {
    IsOpenQuestDialog?.Invoke(true);
    GameStateController.Instance.SetState(GameState.Dialogue);
  }

  public void CloseDialog()
  {
    IsOpenQuestDialog?.Invoke(false);
    GameStateController.Instance.SetState(GameState.Gameplay);

  }

  public void AcceptQuest()
  {
    //questSystem.AcceptQuest(config, this);   old version
    questSystem.AcceptQuest(currentQuestConfig, this);

  }
  public void Complete()
  {
    //questSystem.CompletedQuest(config);  old version
    questSystem.CompletedQuest(currentQuestConfig);
    isAcceptedQuest = false;
    currentQuestNumber++;
    CloseDialog();
  }

  public void ChangeQuestStatus()
  {
    isAcceptedQuest = true;
  }

}