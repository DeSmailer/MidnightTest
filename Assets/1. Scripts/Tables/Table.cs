using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IPurchased
{
    [SerializeField] private List<CharacterPosition> _waiterPositions;
    [SerializeField] private List<CharacterPosition> _visitorPositions;

    [SerializeField] private string _name = "Стол";
    [SerializeField] protected int _number;
    //[Range(1, 10)] [SerializeField] private int _serialNumberUponPurchase;

    [SerializeField] protected bool _isPurchased;

    public string Name => _name;
    public double Price => TableCostCalculator.GetCost(_number);
    public bool IsPurchased => _isPurchased;

    public void Initialize()
    {
        gameObject.SetActive(false);
    }

    public bool CanBuy(CurrencyManager currencyManager)
    {
        if (currencyManager.Currency >= Price)
        {
            return true;
        }
        return false;
    }

    public void Buy(CurrencyManager currencyManager)
    {
        currencyManager.SubtractCurrency(Price);

        gameObject.SetActive(true);

        _isPurchased = true;
    }

    //private void ActivateHobs()
    //{
    //    _activeHobs = new List<Hob>();

    //    for (int i = 0; i < HobData.CurrentNumberOfJobs; i++)
    //    {
    //        _hobs[i].gameObject.SetActive(true);
    //        _activeHobs.Add(_hobs[i]);
    //    }
    //}
}