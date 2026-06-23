using TMPro;
using UnityEngine;

public class PlayerLevelUI : MonoBehaviour
{
  public TMP_Text textField;

  public PlayerLevel playerLevel;

  void Awake()
  {
    if (playerLevel == null) return;
    playerLevel.OnLevelUpdate += ShowLevel;
    playerLevel.OnLevelDataLoaded += SetLoadedLevel;
    ShowLevel(playerLevel.CurrentLevel);
  }

  public void ShowLevel(int level)
  {
    textField.text = level.ToString();
  }
  public void SetLoadedLevel()
  {
    textField.text = playerLevel.CurrentLevel.ToString();
  }

  void OnDisable()
  {
    if (playerLevel == null) return;
    playerLevel.OnLevelUpdate -= ShowLevel;
    playerLevel.OnLevelDataLoaded -= SetLoadedLevel;
  }
}