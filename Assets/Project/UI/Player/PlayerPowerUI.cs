using TMPro;
using UnityEngine;

public class PlayerPowerUI : MonoBehaviour
{
  public TMP_Text textField;
  public PlayerPower playerPower;

  void Awake()
  {
    if (playerPower == null) return;
    playerPower.OnBpChanged += ShowBP;
  }
  public void ShowBP(int bp)
  {
    textField.text = bp.ToString();
  }

  void OnDisable()
  {
    if (playerPower == null) return;
    playerPower.OnBpChanged -= ShowBP;
  }
}