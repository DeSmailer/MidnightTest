using System;
using UnityEngine;

public static class HobSurfacePriceCalculator
{
    //https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing

    public static double GetPurchasePrice(int serialNumberUponPurchase)
    {
        double res = Math.Pow(7 * serialNumberUponPurchase, serialNumberUponPurchase);
        return res;
    }
}
