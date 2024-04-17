using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHobSurface : MonoBehaviour, IPurchased
{
    ///указано что мы готовим, сколько это стоит, сколько открыто рабочих поверхностей

    [SerializeField] private int _serialNumberUponPurchase;

    //private GameObject _foodPrefab;
    //private Transform[] _hobSurfacesPositions;

    [SerializeField] private GameObject _mainHobSurface;
    [SerializeField] private HobSurface[] _hobSurfaces;

    [SerializeField] protected bool _isPurchased;

    public double Price => HobSurfacePriceCalculator.GetPurchasePrice(_serialNumberUponPurchase);
    public bool IsPurchased => _isPurchased;

    private void Start()
    {
        _mainHobSurface.gameObject.SetActive(false);
        for (int i = 0; i < _hobSurfaces.Length; i++)
        {
            _hobSurfaces[i].gameObject.SetActive(false);
        }
    }

    //public void Initialize(Transform myPosition, Transform[] hobSurfacesPositions, GameObject foodPrefab, HobSurface hobSurfacePrefab)
    //{
    //    _foodPrefab = foodPrefab;
    //    _hobSurfacesPositions = hobSurfacesPositions;
    //}

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

        _mainHobSurface.gameObject.SetActive(true);
        _hobSurfaces[0].gameObject.SetActive(true);

        _isPurchased = true;
    }
}
