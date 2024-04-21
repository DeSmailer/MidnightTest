using System;
using UnityEngine;

public class TableBuyer : Buyer, IPurchased
{
    [SerializeField] protected Table _table;

    public override string Name => "Стол";
    public override double Price => TableCostCalculator.GetCost(_number);

    public Action<Table> OnPurchase;

    public override void Buy(CurrencyManager currencyManager)
    {
        base.Buy(currencyManager);

        OnPurchase?.Invoke(_table);
    }
}
