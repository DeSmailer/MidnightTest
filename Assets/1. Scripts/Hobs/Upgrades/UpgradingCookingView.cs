using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradingCookingView : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] protected CurrencyManager _currencyManager;
    [SerializeField] protected HobData _hobData;

    [Header("CurrentValue")]
    [SerializeField] protected TMP_Text _currentValueText;

    [Header("Slider")]
    [SerializeField] protected Slider _slider;
    [SerializeField] protected TMP_Text _minLvlText;
    [SerializeField] protected TMP_Text _maxLvlText;

    [Header("BuyButton")]
    [SerializeField] protected TMP_Text _costText;
    [SerializeField] protected Button _buyButton;
    [SerializeField] protected Image _buttonImage;

    [Header("MaxLvlReached")]
    [SerializeField] protected GameObject _maxLvlReached;

    [Header("BuyButtonColors")]
    [SerializeField] protected Color _activeButtonColor;
    [SerializeField] protected Color _inactiveButtonColor;

    public virtual void Initialize(HobData hobData, CurrencyManager currencyManager)
    {
        _currencyManager = currencyManager;
        _hobData = hobData;

        _buyButton.gameObject.SetActive(true);
        _maxLvlReached.gameObject.SetActive(false);

        InitializeSlider();

        Display();
        Subscribe();
    }

    protected abstract void InitializeSlider();

    public abstract void TryUpgrade();

    public abstract void Display();

    public abstract void DisplayBuyButton();

    protected abstract void SelectButtonColor();

    public void DisplayMaxLvlReached()
    {
        _buyButton.gameObject.SetActive(false);
        _maxLvlReached.gameObject.SetActive(true);
    }

    public virtual void Subscribe()
    {
        _buyButton.onClick.AddListener(TryUpgrade);
        _currencyManager.OnCurrencyCange.AddListener(SelectButtonColor);
    }

    public virtual void Unsubscribe()
    {
        _buyButton.onClick.RemoveListener(TryUpgrade);
        _currencyManager.OnCurrencyCange.RemoveListener(SelectButtonColor);
    }
}
