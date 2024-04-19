using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class CookingDurationCalculator
{
    private const double SECONDS_PER_LEVEL = 5;
    private const double PERCENTAGE_REDUCTION_PER_LEVEL = 0.009;

    private static double GetInitialDuration(int serialNumberUponPurchase)
    {
        return serialNumberUponPurchase * SECONDS_PER_LEVEL;
    }

    public static double GetDuration(int serialNumberUponPurchase, int currentLvl)
    {
        double initialDuration = GetInitialDuration(serialNumberUponPurchase);
        double res = initialDuration - initialDuration * PERCENTAGE_REDUCTION_PER_LEVEL * (currentLvl - 1);
        return res;
    }
}