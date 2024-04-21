using System;
using UnityEngine;

public class WaiterBuyer : Buyer, IPurchased
{
    [SerializeField] protected Waiter _waiter;

    public override string Name => "ќфициант";
    public override double Price => WaiterCostCalculator.GetCost(_number);

    public Action<Waiter> OnPurchase;

    public override void Buy(CurrencyManager currencyManager)
    {
        base.Buy(currencyManager);

        OnPurchase?.Invoke(_waiter);
    }
}