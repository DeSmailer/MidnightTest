public static class HobSurfacePriceCalculator
{
    public static double GetPurchasePrice(int serialNumberUponPurchase)
    {
        return 6 + (10 ^ serialNumberUponPurchase);
    }
}
