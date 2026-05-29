using TMPro;
using UnityEngine;

public class PlayerExpUI : MonoBehaviour
{
  public TMP_Text textField;
  public PlayerLevel playerLevel;

  void Start()
  {
    if (playerLevel == null) return;
    playerLevel.OnCurrentExpChanged += ShowExp;
    ShowExp(playerLevel.CurrentExp);
  }

  public void ShowExp(float value)
  {
    textField.text = value.ToString() + " / " + playerLevel.ExpToNextLevel;
  }

  void OnDisable()
  {
    if (playerLevel == null) return;
    playerLevel.OnCurrentExpChanged -= ShowExp;
  }
}