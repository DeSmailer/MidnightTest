using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    private List<IPurchased> _purchases;
    [SerializeField] private List<GameObject> _purchasesGameobjects;
    [SerializeField] private IPurchased[] purchases;

    public List<IPurchased> Purchases => _purchases;

    public void Initialize()
    {
        _purchases = new List<IPurchased>();

        foreach (GameObject go in _purchasesGameobjects)
        {
            IPurchased purchased = go.GetComponent<IPurchased>();
            if (purchased != null)
            {
                _purchases.Add(purchased);
                purchased.MakeInactive();
            }
        }

        _purchases = _purchases.OrderBy(p => p.Price).ToList();
    }
}
