using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private DishesForCooking _dishesForCooking;

    public void AddOrder(Order order)
    {
        for (int i = 0; i < order.dishCountInOrder.count; i++)
        {
            _dishesForCooking.AddToList(new DishInOrder(order.dishCountInOrder.dish, order));
        }
    }
}
