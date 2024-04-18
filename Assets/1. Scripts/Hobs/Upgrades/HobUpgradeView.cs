using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobUpgradeView : MonoBehaviour, IPopUp
{
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private MainHob _mainHob;

    [SerializeField] private UpgradingDishCostView _upgradingDishCostView;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _upgradingDishCostView.Unsubscribe();
    }

    public void Initialize(MainHob mainHob)
    {
        _mainHob = mainHob;
        _upgradingDishCostView.Initialize(_mainHob.HobData, _currencyManager);
    }

}
