public class UpgradingDishCostView : UpgradingCookingView
{
    protected override void InitializeSlider()
    {
        _slider.maxValue = _hobData.MaxCostOfDishLvl;
        _slider.minValue = 1;
        _maxLvlText.text = _hobData.MaxCostOfDishLvl.ToString();
        _minLvlText.text = "1";
    }

    public override void TryUpgrade()
    {
        if (_hobData.UpgradingCostDishCost <= _currencyManager.Currency)
        {
            _currencyManager.SubtractCurrency(_hobData.UpgradingCostDishCost);
            _hobData.CostOfDishLvl++;

            Display();
        }
    }

    public override void Display()
    {
        _currentValueText.text = CurrencyFormatDisplay.Display(_hobData.CostOfDish);
        _slider.value = _hobData.CostOfDishLvl;

        if (_hobData.CostOfDishLvl < _hobData.MaxCostOfDishLvl)
        {
            DisplayBuyButton();
        }
        else
        {
            DisplayMaxLvlReached();
        }
    }

    public override void DisplayBuyButton()
    {
        _costText.text = CurrencyFormatDisplay.Display(_hobData.UpgradingCostDishCost);
        SelectButtonColor();
    }

    protected override void SelectButtonColor()
    {
        if (_hobData.UpgradingCostDishCost <= _currencyManager.Currency)
        {
            _buttonImage.color = _activeButtonColor;
        }
        else
        {
            _buttonImage.color = _inactiveButtonColor;
        }
    }
}
