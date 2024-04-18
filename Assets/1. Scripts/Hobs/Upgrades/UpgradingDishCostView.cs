using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradingDishCostView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentDishCostText;

    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _buyButton;

    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private HobData _hobData;

    public void Initialize(HobData hobData, CurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
        _hobData = hobData;

        Display();

        _buyButton.onClick.AddListener(Upgrade);
    }

    public void Display()
    {
        _currentDishCostText.text = CurrencyFormatDisplay.Display(_hobData.CostOfDish);
        _costText.text = CurrencyFormatDisplay.Display(_hobData.UpgradingCostDishCost);
    }

    public void Upgrade()
    {
        if (_hobData.UpgradingCostDishCost <= _currencyManager.Currency)
        {
            _hobData.CostOfDishLvl++;
            _currencyManager.SubtractCurrency(_hobData.UpgradingCostDishCost);

            Display();
        }
    }

    public void Unsubscribe()
    {
        _buyButton.onClick.RemoveListener(Upgrade);
    }
}
