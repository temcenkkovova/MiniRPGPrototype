using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  public QuestConfig config;
  public QuestSystem questSystem;

  private bool isAcceptedQuest = false;
  public bool IsAcceptedQuest => isAcceptedQuest;

  public event Action<bool> IsOpenQuestDialog;

  public bool CheckQuestCompleteStatus()
  {
    bool status = false;

    QuestData questData = questSystem.acceptedQuests.Find(item => item.Config.name == config.name);
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
    questSystem.AcceptQuest(config, this);

  }

  public void ChangeQuestStatus()
  {
    isAcceptedQuest = true;
  }

}