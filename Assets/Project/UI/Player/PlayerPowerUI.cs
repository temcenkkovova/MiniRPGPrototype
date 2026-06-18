using TMPro;
using UnityEngine;

public class PlayerPowerUI : MonoBehaviour
{
  public TMP_Text textField;
  public PlayerTotalPower playerPower;

  void Awake()
  {
    if (playerPower == null) return;
    playerPower.OnBpChanged += ShowBP;
  }
  public void ShowBP(int bp)
  {
    textField.text = bp.ToString("F0");
  }

  void OnDisable()
  {
    if (playerPower == null) return;
    playerPower.OnBpChanged -= ShowBP;
  }
}