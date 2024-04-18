using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class HobCostCalculator
{
    public static double GetCost(int serialNumberUponPurchase)
    {
        double res = Math.Pow(7 * serialNumberUponPurchase, serialNumberUponPurchase);
        return res;
    }
}
