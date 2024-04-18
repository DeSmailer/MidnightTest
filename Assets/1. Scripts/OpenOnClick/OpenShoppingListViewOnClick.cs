using UnityEngine;

public class OpenShoppingListViewOnClick : OpenOnClick
{
    [SerializeField] protected ShoppingListView _shoppingListView ;

    public override void Open()
    {
        _shoppingListView.Open();
    }
}
