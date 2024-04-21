using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderView : MonoBehaviour
{
    private Order _order;

    public void Initialize(Order order)
    {
        _order = order;
        foreach (DishCountInOrder dishCountInOrder in _order.dishCountInOrders)
        {
            dishCountInOrder.OnDishReceived += Display;
        }
    }

    public void Display()
    {

    }
}
