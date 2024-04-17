using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListView : MonoBehaviour
{
    [SerializeField] private ShoppingListItemView _shoppingListItemViewPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private ShoppingList _shoppingList;
    [SerializeField] private CurrencyManager _currencyManager;

    private void OnEnable()
    {
        Display();
    }

    public void Display()
    {
        foreach (var purchase in _shoppingList.Purchases)
        {
            ShoppingListItemView shoppingListItem = Instantiate(_shoppingListItemViewPrefab, _container);
            shoppingListItem.Initialize(purchase, _currencyManager);
        }
    }
}
