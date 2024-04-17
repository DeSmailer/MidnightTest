using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShoppingListItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private IPurchased _purchased;
    /* [SerializeField] */
    private CurrencyManager _currencyManager;

    public void Initialize(IPurchased purchased, CurrencyManager currencyManager)
    {
        _purchased = purchased;
        _currencyManager = currencyManager;

        _costText.text = CurrencyFormatDisplay.Display(_purchased.Price);
        _buyButton.onClick.AddListener(Buy);
    }

    public void Buy()
    {
        if (_purchased.CanBuy(_currencyManager))
        {
            _purchased.Buy(_currencyManager);
        }
    }
}
