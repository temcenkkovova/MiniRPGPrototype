using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

  public int CurrentLevel { get; private set; } = 1;
  private PlayerConfig config;
  public float CurrentExp { get; private set; }
  public float ExpToNextLevel { get; private set; }
  public float MultiplyExp { get; private set; }
  public event Action<int> OnLevelUpdate;
  public event Action<float> OnCurrentExpChanged;


  public void Init(PlayerConfig playerConfig)
  {
    config = playerConfig;
    ExpToNextLevel = config.expToNextLevel;
    MultiplyExp = config.multiplyExp;
  }

  public void AddExp(float expValue)
  {
    CurrentExp += expValue;
    OnCurrentExpChanged?.Invoke(CurrentExp);
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
    OnCurrentExpChanged?.Invoke(CurrentExp);
    OnLevelUpdate?.Invoke(CurrentLevel);

  }

  public void InitSaveLevelData(int saveLevel, float saveExp)
  {
    CurrentLevel = saveLevel;
    CurrentExp = saveExp;
  }
}