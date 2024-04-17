using TMPro;
using UnityEngine;

public class CurencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private CurrencyManager _currencyManager;

    private void Awake()
    {
        _currencyManager.OnCurrencyCange.AddListener(Display);
    }

    private void Start()
    {
        Display();
    }

    public void Display()
    {
        _currencyText.text = CurrencyFormatDisplay.Display(_currencyManager.Currency);
    }
}
