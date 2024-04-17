using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShoppingListItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private IPurchased _purchased;


    public void Initialize(IPurchased purchased)
    {
        _purchased = purchased;
        _costText.text = CurrencyFormatDisplay.Display(_purchased.Price);
        _buyButton.onClick.AddListener(Buy);
    }

    public void Buy()
    {
        _purchased.Buy();
    }
}
