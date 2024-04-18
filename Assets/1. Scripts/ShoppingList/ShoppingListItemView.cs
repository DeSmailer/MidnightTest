using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShoppingListItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _buyButton;

    private IPurchased _purchased;
    private CurrencyManager _currencyManager;

    public void Initialize(IPurchased purchased, CurrencyManager currencyManager)
    {
        _purchased = purchased;
        _currencyManager = currencyManager;

        _nameText.text = purchased.Name;
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
