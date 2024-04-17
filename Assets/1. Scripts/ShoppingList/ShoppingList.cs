using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    private List<IPurchased> _purchases;
    [SerializeField] private List<GameObject> _purchasesGameobjects;
    [SerializeField] private IPurchased[] purchases;

    public List<IPurchased> Purchases => _purchases;

    private void Awake()
    {
        _purchases = new List<IPurchased>();

        foreach (GameObject go in _purchasesGameobjects)
        {
            IPurchased purchased = go.GetComponent<IPurchased>();
            if (purchased != null)
            {
                _purchases.Add(purchased);
            }
        }
    }
}
