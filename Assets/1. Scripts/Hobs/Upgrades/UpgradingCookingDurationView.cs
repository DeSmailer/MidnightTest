public class UpgradingCookingDurationView : UpgradingCookingView
{
    protected override void InitializeSlider()
    {
        _slider.maxValue = _hobData.MaxCookingDurationLvl;
        _slider.minValue = 1;
        _maxLvlText.text = _hobData.MaxCookingDurationLvl.ToString();
        _minLvlText.text = "1";
    }

    public override void TryUpgrade()
    {
        if (_hobData.UpgradingCookingDurationCost <= _currencyManager.Currency)
        {
            _currencyManager.SubtractCurrency(_hobData.UpgradingCookingDurationCost);
            _hobData.CookingDurationLvl++;

            Display();
        }
    }

    public override void Display()
    {
        _currentValueText.text = _hobData.CookingDuration.ToString() + " s";
        _slider.value = _hobData.CookingDurationLvl;

        if (_hobData.CookingDurationLvl < _hobData.MaxCookingDurationLvl)
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
        _costText.text = CurrencyFormatDisplay.Display(_hobData.UpgradingCookingDurationCost);
        SelectButtonColor();
    }

    protected override void SelectButtonColor()
    {
        if (_hobData.UpgradingCookingDurationCost <= _currencyManager.Currency)
        {
            _buttonImage.color = _activeButtonColor;
        }
        else
        {
            _buttonImage.color = _inactiveButtonColor;
        }
    }
}
