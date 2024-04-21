using System;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class Order
{
    public List<DishCountInOrder> dishCountInOrders;
    public Table table;
    public Visitor visitor;

    public Order(DishCountInOrder dishCountInOrder, Table table, Visitor visitor)
    {
        dishCountInOrders = new List<DishCountInOrder>();
        dishCountInOrders.Add(dishCountInOrder);

        this.table = table;
        this.visitor = visitor;

        Debug.Log("dishCountInOrder " + dishCountInOrder.dish.Name + " table " + table + " visitor " + visitor);
    }

    public Order(List<DishCountInOrder> dishCountInOrders, Table table, Visitor visitor)
    {
        this.dishCountInOrders = dishCountInOrders;

        this.table = table;
        this.visitor = visitor;
    }
}

public class DishCountInOrder
{
    public DishOnLevel dish;
    public int count;
    public DishCountInOrder(DishOnLevel dish, int count)
    {
        this.dish = dish;
        this.count = count;
    }
}
