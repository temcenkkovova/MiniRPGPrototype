using UnityEngine;
[CreateAssetMenu(menuName = "Quest")]
public class QuestConfig : ScriptableObject
{
  public string title;
  public string description;
  public string EnemyNameToKill;
  public int RequiredKills;
  public int rewardCoins;
  public int RewardExp;

}