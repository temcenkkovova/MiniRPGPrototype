using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
  public GameObject healthBar;
  public Image backgroundImage;
  public Image fillImage;
  public TMP_Text textField;

  public EnemyHealth enemyHealth;

  void Awake()
  {
    if (enemyHealth == null) return;
    enemyHealth.OnHealthChanged += ShowHealth;
  }
  public void ShowHealth(float health)
  {

    textField.text = health.ToString() + " / " + enemyHealth.MaxHealth;
  }

}