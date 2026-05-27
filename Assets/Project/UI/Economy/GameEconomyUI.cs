using TMPro;
using UnityEngine;

public class GameEconomyUI : MonoBehaviour
{
  public GameEconomy gameEconomy;

  public TMP_Text currencyField;

  void Awake()
  {
    if (gameEconomy == null) return;
    gameEconomy.OnCurrencyChanged += ShowCurrency;
  }

  void Start()
  {
    if (gameEconomy == null) return;
    ShowCurrency(gameEconomy.CurrentCurrency);
  }

  public void ShowCurrency(float totalCurrency)
  {
    if (currencyField != null)
    {
      currencyField.text = totalCurrency.ToString();
    }
  }

  void OnDisable()
  {
    if (gameEconomy == null) return;
    gameEconomy.OnCurrencyChanged -= ShowCurrency;
  }
}