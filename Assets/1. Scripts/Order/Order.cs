using System;

//[Serializable]
public class Order
{
    public DishCountInOrder dishCountInOrder;
    public Table table;
    public Visitor visitor;

    public Order(DishCountInOrder dishCountInOrder, Table table, Visitor visitor)
    {
        this.dishCountInOrder = dishCountInOrder;

        this.table = table;
        this.visitor = visitor;

    }
}

public class DishCountInOrder
{
    public DishOnLevel dish;
    public int count;

    public Action OnDishReceived;

    public DishCountInOrder(DishOnLevel dish, int count)
    {
        this.dish = dish;
        this.count = count;
    }

    public void DishReceived()
    {
        count--;
        OnDishReceived?.Invoke();
    }
}
