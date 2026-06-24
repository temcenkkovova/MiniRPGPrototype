using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  public QuestConfig config;
  public QuestSystem questSystem;

  public event Action<bool> IsOpenQuestDialog;

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

}