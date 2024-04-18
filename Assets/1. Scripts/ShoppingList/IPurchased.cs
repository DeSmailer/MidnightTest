public interface IPurchased
{
    public string Name { get; }
    public double Price { get; }
    public bool IsPurchased { get; }

    public bool CanBuy(CurrencyManager currencyManager);
    public void Buy(CurrencyManager currencyManager);
}
