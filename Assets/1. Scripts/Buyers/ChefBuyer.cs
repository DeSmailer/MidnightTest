using System;
using UnityEngine;

public class ChefBuyer : Buyer, IPurchased
{
    [SerializeField] protected Chef _chef;

    public override string Name => "Повар";
    public override double Price => ChefCostCalculator.GetCost(_number);

    public Action<Chef> OnPurchase;

    public override void Buy(CurrencyManager currencyManager)
    {
        base.Buy(currencyManager);

        _chef.FindJob();
        OnPurchase?.Invoke(_chef);
    }
}