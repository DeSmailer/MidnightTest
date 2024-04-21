using UnityEngine;

public abstract class Buyer : MonoBehaviour, IPurchased
{
    [SerializeField] protected string _name = "Повар";
    [SerializeField] protected int _number;

    [SerializeField] protected bool _isPurchased;

    public abstract string Name { get; }
    public abstract double Price { get; }
    public bool IsPurchased => _isPurchased;

    public virtual void MakeInactive()
    {
        gameObject.SetActive(false);
    }

    public virtual bool CanBuy(CurrencyManager currencyManager)
    {
        if (currencyManager.Currency >= Price)
        {
            return true;
        }
        return false;
    }

    public virtual void Buy(CurrencyManager currencyManager)
    {
        currencyManager.SubtractCurrency(Price);

        gameObject.SetActive(true);

        _isPurchased = true;
    }
}