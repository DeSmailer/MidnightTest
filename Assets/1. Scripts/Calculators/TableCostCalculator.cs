using System;

//https://docs.google.com/spreadsheets/d/1SDo__HAHj6sR4IdLvgtswTXHGXDqqHFnFjLwR45mGTs/edit?usp=sharing
public static class TableCostCalculator
{
    private const float COEFFICIENT_A = 5;

    public static double GetCost(int number)
    {
        double res = Math.Pow(COEFFICIENT_A, number) * Math.Pow(number, number);
        return res;
    }
}