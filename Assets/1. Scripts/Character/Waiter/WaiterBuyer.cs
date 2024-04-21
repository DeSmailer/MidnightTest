using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterBuyer : MonoBehaviour, IPurchased
{
    [SerializeField] private string _name = "ќфициант";
    [SerializeField] protected int _number;

    [SerializeField] protected Waiter _waiter;

    [SerializeField] protected bool _isPurchased;

    public string Name => _name;
    public double Price => WaiterCostCalculator.GetCost(_number);
    public bool IsPurchased => _isPurchased;

    public Action<Waiter> OnPurchase;

    public void MakeInactive()
    {
        gameObject.SetActive(false);
    }

    public bool CanBuy(CurrencyManager currencyManager)
    {
        if (currencyManager.Currency >= Price)
        {
            return true;
        }
        return false;
    }

    public void Buy(CurrencyManager currencyManager)
    {
        currencyManager.SubtractCurrency(Price);

        gameObject.SetActive(true);

        _isPurchased = true;
        OnPurchase?.Invoke(_waiter);
    }
}