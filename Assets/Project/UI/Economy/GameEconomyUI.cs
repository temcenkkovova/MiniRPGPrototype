using TMPro;
using UnityEngine;

public class GameEconomyUI : MonoBehaviour
{
  public GameEconomy gameEconomy;

  public TMP_Text currencyField;
  public PopupManager popupManager;
  public Transform economyPanel;

  void Awake()
  {
    if (gameEconomy == null) return;
    gameEconomy.OnCurrencyChanged += ShowCurrency;
  }

  void Start()
  {
    if (gameEconomy == null) return;
    currencyField.text = gameEconomy.CurrentCurrency.ToString("F0");
  }

  public void ShowCurrency(float totalCurrency)
  {
    if (currencyField == null || popupManager == null) return;

    string transformedText = "+ " + totalCurrency.ToString("F0");
    popupManager.ShowUI(transformedText, economyPanel, Color.yellow);
    currencyField.text = totalCurrency.ToString("F0");

  }

  void OnDisable()
  {
    if (gameEconomy == null) return;
    gameEconomy.OnCurrencyChanged -= ShowCurrency;
  }
}