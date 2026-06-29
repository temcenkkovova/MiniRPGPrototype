using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{

  public TMP_Text title;
  public TMP_Text condition;
  private QuestData itemData;
  public Button questBtn;


  public void Init(QuestData item)
  {
    if (item == null) return;
    itemData = item;
    title.text = item.Config.title;
    condition.text = item.Config.EnemyNameToKill + "  " + "defeated " + " " + item.CurrentKills + " / " + item.Config.RequiredKills;

    item.OnCurrentKillsChanged += ChangeQuestProgress;
    if (itemData.isCompleted)
    {
      questBtn.interactable = false;
    }
  }

  public void ChangeQuestProgress(int progressValue)
  {
    condition.text = itemData.Config.EnemyNameToKill + "  " + "defeated " + " " + progressValue + " / " + itemData.Config.RequiredKills;
    if (itemData.isCompleted)
    {
      questBtn.interactable = false;
    }
  }

  void OnDisable()
  {
    if (itemData == null) return;
    itemData.OnCurrentKillsChanged -= ChangeQuestProgress;
  }
}