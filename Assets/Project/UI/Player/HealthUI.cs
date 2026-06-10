using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
  public TMP_Text healthTextField;
  public PlayerHealth playerHealth;

  void Awake()
  {
    if (playerHealth == null) return;

    playerHealth.OnHealthChanged += ShowHealth;
  }

  public void ShowHealth(float health)
  {
    healthTextField.text = health.ToString("F0");
  }

  void OnDisable()
  {
    playerHealth.OnHealthChanged -= ShowHealth;
  }
}