using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
  public TMP_Text healthTextField;
  public PlayerHealth playerHealth;
  public Image hpFill;
  public Image hpDelayedFill;
  public float delaySpeed = 1f;
  private bool active;
  private float target;
  private float maxHpPlayer;


  void Start()
  {
    if (playerHealth == null) return;

    playerHealth.OnHealthChanged += ShowHealth;
    maxHpPlayer = playerHealth.CurrentHealth;

    ShowHealth(playerHealth.CurrentHealth);
  }

  public void ShowHealth(float health)
  {
    active = health > 0;
    target = health / maxHpPlayer;
    hpFill.fillAmount = target;
    healthTextField.text = health.ToString("F0");
  }

  void OnDisable()
  {
    playerHealth.OnHealthChanged -= ShowHealth;
  }
  void Update()
  {
    if (!active) return;
    hpDelayedFill.fillAmount = Mathf.Lerp(hpDelayedFill.fillAmount, target, Time.deltaTime * delaySpeed);

  }
}