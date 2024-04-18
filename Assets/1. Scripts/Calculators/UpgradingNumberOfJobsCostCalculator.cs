using System;
using UnityEngine;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class UpgradingNumberOfJobsCostCalculator
{
    private const int NUMBER_OF_DISHES = 10;
    private const int coef = 20;

    public static double GetCost(int serialNumberUponPurchase, int currentNumberOfJobs)
    {
        int nexNumberOfJobs = currentNumberOfJobs + 1;

        int lvl = 0;
        switch (nexNumberOfJobs)
        {
            case 2:
                lvl = 10;
                break;
            case 3:
                lvl = 25;
                break;
            case 4:
                lvl = 50;
                break;
            default:
                Debug.LogError(currentNumberOfJobs + " - max 3");
                break;
        }

        double costOfDish = DishCostCalculator.GetCost(serialNumberUponPurchase, lvl);
        double res = nexNumberOfJobs * NUMBER_OF_DISHES * costOfDish * lvl / coef;
        return res;
    }
}