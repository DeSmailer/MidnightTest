using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListView : MonoBehaviour, IPopUp
{
    [SerializeField] private ShoppingListItemView _shoppingListItemViewPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private ShoppingList _shoppingList;
    [SerializeField] private CurrencyManager _currencyManager;

    private bool _initialized = false;

    public void Open()
    {
        if (!_initialized)
        {
            Initialize();
            _initialized = true;
        }
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        foreach (var purchase in _shoppingList.Purchases)
        {
            ShoppingListItemView shoppingListItem = Instantiate(_shoppingListItemViewPrefab, _container);
            shoppingListItem.Initialize(purchase, _currencyManager);
        }
    }
}
