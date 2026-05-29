using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

  public int CurrentLevel { get; private set; } = 1;
  private PlayerConfig config;
  public float CurrentExp { get; private set; }
  public float ExpToNextLevel { get; private set; }
  public float MultiplyExp { get; private set; }


  private PlayerBootstrap player; // I'll need the player to update PlayerStats when the player levels up.
  void Awake()
  {
    player = GetComponent<PlayerBootstrap>();
  }

  public void Init(PlayerConfig playerConfig)
  {
    config = playerConfig;
    ExpToNextLevel = config.expToNextLevel;
    MultiplyExp = config.multiplyExp;
  }

  public void AddExp(float expValue)
  {
    CurrentExp += expValue;
    while (CurrentExp >= ExpToNextLevel)
    {
      LevelUp();
    }
  }

  public void LevelUp()
  {
    CurrentLevel++;
    CurrentExp -= ExpToNextLevel;
    ExpToNextLevel *= MultiplyExp;
  }
}