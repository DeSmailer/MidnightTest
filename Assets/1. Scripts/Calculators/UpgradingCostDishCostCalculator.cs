using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class UpgradingCostDishCostCalculator
{
    private const int NUMBER_OF_DISHES = 3;

    public static double GetCost(int serialNumberUponPurchase, int currentLvl)
    {
        double res = Math.Pow(2, serialNumberUponPurchase) * serialNumberUponPurchase
            * Math.Pow(serialNumberUponPurchase, serialNumberUponPurchase) * currentLvl * NUMBER_OF_DISHES;
        return res;
    }
}