using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private double _currency;
    public double Currency => _currency;

    public UnityEvent OnCurrencyCange;

    public void AddCurrency(double count)
    {
        _currency += count;
        OnCurrencyCange?.Invoke();
    }

    public void SubtractCurrency(double count)
    {
        _currency -= count;
        OnCurrencyCange?.Invoke();
    }
}
