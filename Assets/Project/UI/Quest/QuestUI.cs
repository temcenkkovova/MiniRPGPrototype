using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
  public TMP_Text title;
  public TMP_Text description;
  public TMP_Text condition;
  public TMP_Text expReward;
  public TMP_Text coinReward;
  private Quest quest;


  public void Init(QuestConfig data, Quest quest)
  {
    title.text = data.title;
    description.text = data.description;
    condition.text = "Defeat " + data.RequiredKills + data.EnemyNameToKill;
    coinReward.text = data.rewardCoins.ToString();
    expReward.text = data.RewardExp.ToString();

    this.quest = quest;
  }


  public void HandleCloseDialog()
  {
    if (!quest) return;
    quest.CloseDialog();
  }

  public void HandleAccept()
  {
    if (!quest) return;
    quest.AcceptQuest();
  }

}