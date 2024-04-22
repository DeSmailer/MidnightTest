using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DishesForCooking : MonoBehaviour
{
    private List<DishInOrder> _dishes = new List<DishInOrder>();

    public List<DishInOrder> DishInOrders => _dishes;

    public UnityEvent OnAdded;

    public void AddToList(DishInOrder dishInOrder)
    {
        _dishes.Add(dishInOrder);
        OnAdded?.Invoke();
    }

    public DishInOrder GetFromList()
    {
        if (_dishes.Count > 0)
        {
            return _dishes.FirstOrDefault(x => x.dishInOrderState == DishInOrderState.Free);
        }
        else
        {
            return null;
        }
    }

    public DishInOrder GetAndRemoveFromList()
    {
        DishInOrder dishInOrder = GetFromList();
        if (dishInOrder != null)
        {
            _dishes.Remove(dishInOrder);
        }
        return dishInOrder;
    }
}
