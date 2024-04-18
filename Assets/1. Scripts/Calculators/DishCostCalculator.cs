using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class DishCostCalculator
{
    public static double GetCost(int serialNumberUponPurchase, int currentLvl)
    {
        double res = Math.Pow(2, serialNumberUponPurchase) * serialNumberUponPurchase
            * Math.Pow(serialNumberUponPurchase, serialNumberUponPurchase) * currentLvl;
        return res;
    }
}
