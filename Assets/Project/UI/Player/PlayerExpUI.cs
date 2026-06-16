
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpUI : MonoBehaviour
{
  public TMP_Text textField;
  public PlayerLevel playerLevel;
  private float delaySpeed = 1f;
  public Image fillImage;
  private float target;

  void Start()
  {
    if (playerLevel == null) return;
    playerLevel.OnCurrentExpChanged += ShowExp;
    ShowExp(playerLevel.CurrentExp);
    fillImage.fillAmount = 0f;
  }
  void Update()
  {
    fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, target, Time.deltaTime * delaySpeed);

  }

  public void ShowExp(float value)
  {

    textField.text = value.ToString("F4") + " / " + playerLevel.ExpToNextLevel.ToString("F4");
    target = playerLevel.CurrentExp / playerLevel.ExpToNextLevel;
    if (playerLevel.CurrentExp >= playerLevel.ExpToNextLevel)
    {

      target = 0f;
    }

  }

  void OnDisable()
  {
    if (playerLevel == null) return;
    playerLevel.OnCurrentExpChanged -= ShowExp;
  }
}