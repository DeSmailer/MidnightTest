using System;
using UnityEngine;

public static class HobSurfacePriceCalculator
{
    public static double GetPurchasePrice(int serialNumberUponPurchase)
    {
        double res = Math.Pow(7 * serialNumberUponPurchase, serialNumberUponPurchase);
        Debug.LogError("serialNumberUponPurchase " + serialNumberUponPurchase + "  res " + res);
        return res;
    }
}
