using UnityEngine;

public class PlayerRewardSystem : MonoBehaviour
{
  public PlayerLevel playerLevel;
  public GameEconomy gameEconomy;


  void OnEnable()
  {
    GameEvents.OnQuestCompleted += SetReward;
  }
  public void SetReward(RewardData rewardData)
  {
    playerLevel.AddExp(rewardData.Exp);
    gameEconomy.AddCurrency(rewardData.Coins);
  }


  void OnDisable()
  {
    GameEvents.OnQuestCompleted -= SetReward;
  }
}