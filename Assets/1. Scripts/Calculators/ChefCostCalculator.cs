using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class ChefCostCalculator
{
    private const float COEFFICIENT_A = 2;

    public static double GetCost(int number)
    {
        double res = Math.Pow(COEFFICIENT_A, number) * Math.Pow(number, number);
        return res;
    }
}