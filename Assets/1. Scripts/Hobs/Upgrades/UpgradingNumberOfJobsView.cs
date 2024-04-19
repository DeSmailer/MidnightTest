using UnityEngine;

public class UpgradingNumberOfJobsView : UpgradingCookingView
{
    protected override void InitializeSlider()
    {
        _slider.maxValue = _hobData.MaxNumberOfJobsLvl;
        _slider.minValue = 1;
        _maxLvlText.text = _hobData.MaxNumberOfJobsLvl.ToString();
        _minLvlText.text = "1";
    }

    public override void TryUpgrade()
    {
        double d1 = 16125344;
        double d2 = 15360000;
        Debug.LogError(d1 - d2);

        Debug.Log("UpgradingNumberOfJobsCost " + _hobData.UpgradingNumberOfJobsCost + " - " + "_currencyManager.Currency " + _currencyManager.Currency);

        if (_hobData.UpgradingNumberOfJobsCost <= _currencyManager.Currency)
        {
            _currencyManager.SubtractCurrency(_hobData.UpgradingNumberOfJobsCost);
            _hobData.NumberOfJobsLvl++;

            Display();
        }
    }

    public override void Display()
    {
        _currentValueText.text = _hobData.CurrentNumberOfJobs.ToString();
        _slider.value = _hobData.NumberOfJobsLvl;

        if (_hobData.NumberOfJobsLvl < _hobData.MaxNumberOfJobsLvl)
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
        _costText.text = CurrencyFormatDisplay.Display(_hobData.UpgradingNumberOfJobsCost);
        SelectButtonColor();
    }

    protected override void SelectButtonColor()
    {
        if (_hobData.UpgradingNumberOfJobsCost <= _currencyManager.Currency)
        {
            _buttonImage.color = _activeButtonColor;
        }
        else
        {
            _buttonImage.color = _inactiveButtonColor;
        }
    }
}
