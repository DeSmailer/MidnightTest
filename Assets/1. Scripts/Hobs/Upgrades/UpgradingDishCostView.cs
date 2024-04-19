using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradingDishCostView : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private CurrencyManager _currencyManager;
    [SerializeField] private HobData _hobData;

    [Header("CurrentDishCost")]
    [SerializeField] private TMP_Text _currentDishCostText;

    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _minLvlText;
    [SerializeField] private TMP_Text _maxLvlText;

    [Header("BuyButton")]
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _buttonImage;

    [Header("MaxLvlReached")]
    [SerializeField] private GameObject _maxLvlReached;

    [Header("BuyButtonColors")]
    [SerializeField] private Color _activeButtonColor;
    [SerializeField] private Color _inactiveButtonColor;

    public void Initialize(HobData hobData, CurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
        _hobData = hobData;

        _buyButton.gameObject.SetActive(true);
        _maxLvlReached.gameObject.SetActive(false);

        InitializeSlider();

        Display();
        Subscribe();
    }

    private void InitializeSlider()
    {
        _slider.maxValue = _hobData.MaxCostOfDishLvl;
        _slider.minValue = 1;
        _maxLvlText.text = _hobData.MaxCostOfDishLvl.ToString();
        _minLvlText.text = "1";
    }

    public void TryUpgrade()
    {
        if (_hobData.UpgradingCostDishCost <= _currencyManager.Currency)
        {
            _hobData.CostOfDishLvl++;
            _currencyManager.SubtractCurrency(_hobData.UpgradingCostDishCost);

            Display();
        }
    }

    public void Display()
    {
        _currentDishCostText.text = CurrencyFormatDisplay.Display(_hobData.CostOfDish);
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

    public void DisplayBuyButton()
    {
        _costText.text = CurrencyFormatDisplay.Display(_hobData.UpgradingCostDishCost);
        SelectButtonColor();
    }

    public void DisplayMaxLvlReached()
    {
        _buyButton.gameObject.SetActive(false);
        _maxLvlReached.gameObject.SetActive(true);
    }

    private void SelectButtonColor()
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

    public void Subscribe()
    {
        _buyButton.onClick.AddListener(TryUpgrade);
        _currencyManager.OnCurrencyCange.AddListener(SelectButtonColor);
    }

    public void Unsubscribe()
    {
        _buyButton.onClick.RemoveListener(TryUpgrade);
        _currencyManager.OnCurrencyCange.RemoveListener(SelectButtonColor);
    }
}
