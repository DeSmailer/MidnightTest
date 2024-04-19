using UnityEngine;

public class HobUpgradeView : MonoBehaviour, IPopUp
{
    [SerializeField] private CurrencyManager _currencyManager;
    private MainHob _mainHob;

    [SerializeField] private UpgradingDishCostView _upgradingDishCostView;
    [SerializeField] private UpgradingCookingDurationView _upgradingCookingDurationView;
    [SerializeField] private UpgradingNumberOfJobsView _upgradingNumberOfJobsView;

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
        _upgradingCookingDurationView.Initialize(_mainHob.HobData, _currencyManager);
        _upgradingNumberOfJobsView.Initialize(_mainHob.HobData, _currencyManager);
    }

}
