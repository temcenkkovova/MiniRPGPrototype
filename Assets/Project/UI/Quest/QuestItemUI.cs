using TMPro;
using UnityEngine;

public class QuestItemUI : MonoBehaviour
{

  public TMP_Text title;
  public TMP_Text condition;
  private QuestData itemData;


  public void Init(QuestData item)
  {
    if (item == null) return;
    title.text = item.Config.title;
    condition.text = item.Config.EnemyNameToKill + "  " + "defeated " + " " + item.CurrentKills + " / " + item.Config.RequiredKills;

    item.OnCurrentKillsChanged += ChangeQuestProgress;
  }

  public void ChangeQuestProgress(int progressValue)
  {
    condition.text = itemData.Config.EnemyNameToKill + "  " + "defeated " + " " + progressValue + " / " + itemData.Config.RequiredKills;
  }

  void OnDisable()
  {
    if (itemData == null) return;
    itemData.OnCurrentKillsChanged -= ChangeQuestProgress;
  }
}