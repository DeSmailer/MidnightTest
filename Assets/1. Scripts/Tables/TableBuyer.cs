using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBuyer : MonoBehaviour, IPurchased
{
    [SerializeField] private string _name = "Стол";
    [SerializeField] protected int _number;

    [SerializeField] protected Table _table;
    [SerializeField] protected bool _isPurchased;

    public string Name => _name;
    public double Price => TableCostCalculator.GetCost(_number);
    public bool IsPurchased => _isPurchased;

    public Action<Table> OnPurchase;

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
        OnPurchase?.Invoke(_table);
    }


}
