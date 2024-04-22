public class DishInOrder
{
    public DishOnLevel dish;
    public Order order;
    public DishInOrderState dishInOrderState;

    public DishInOrder(DishOnLevel dish, Order order)
    {
        this.dish = dish;
        this.order = order;
        dishInOrderState = DishInOrderState.Free;
    }
}

public enum DishInOrderState
{
    Free,
    Taken
}
