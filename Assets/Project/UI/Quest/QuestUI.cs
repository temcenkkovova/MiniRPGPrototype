using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
  public TMP_Text title;
  public TMP_Text description;
  public TMP_Text condition;
  public TMP_Text expReward;
  public TMP_Text coinReward;
  private QuestManager quest;
  public Button acceptBtn;
  public Button getRewardBtn;
  public GameObject getRewardPanel;
  public GameObject acceptPanel;



  public void Init(QuestConfig data, QuestManager quest)
  {
    acceptPanel.SetActive(false);
    getRewardPanel.SetActive(false);
    if (quest == null || data == null) return;
    title.text = data.title;
    description.text = data.description;
    condition.text = "Defeat " + data.RequiredKills + data.EnemyNameToKill;
    coinReward.text = data.rewardCoins.ToString();
    expReward.text = data.RewardExp.ToString();

    this.quest = quest;
    if (quest.IsAcceptedQuest)
    {
      getRewardPanel.SetActive(true);
      acceptPanel.SetActive(false);

      getRewardBtn.interactable = quest.CheckQuestCompleteStatus();

    }
    else
    {
      getRewardPanel.SetActive(false);
      acceptPanel.SetActive(true);
    }
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

  public void HandleCompleteQuest()
  {
    if (!quest) return;
    quest.Complete();
  }

}