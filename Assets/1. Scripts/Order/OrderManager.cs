using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<Order> _orders = new List<Order>();

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
}
