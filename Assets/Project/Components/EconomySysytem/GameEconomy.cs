using System;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{

  public float CurrentCurrency { get; private set; }
  public event Action<float> OnCurrencyChanged;
  public EconomyConfig config;

  void Awake()
  {
    CurrentCurrency = config.startCurrency;
  }

  public bool HasEnough(float amount)
  {
    return CurrentCurrency >= amount;
  }

  public void SpendCurrency(float amount)
  {
    CurrentCurrency -= amount;
    OnCurrencyChanged?.Invoke(CurrentCurrency);
  }
  public void AddCurrency(float amount)
  {
    CurrentCurrency += amount;
    OnCurrencyChanged?.Invoke(CurrentCurrency);
  }

}