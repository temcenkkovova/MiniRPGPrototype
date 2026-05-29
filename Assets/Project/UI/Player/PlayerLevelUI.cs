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
    ShowLevel(playerLevel.CurrentLevel);
  }

  public void ShowLevel(int level)
  {
    textField.text = level.ToString();
  }

  void OnDisable()
  {
    if (playerLevel == null) return;
    playerLevel.OnLevelUpdate -= ShowLevel;
  }
}