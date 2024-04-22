using UnityEngine;

public class OrderView : MonoBehaviour
{
    private Order _order;
    [SerializeField] private OrderCloud _orderCloud;

    public void Initialize(Order order)
    {
        _order = order;
        _orderCloud.Toggle(true);

        _order.dishCountInOrder.OnDishReceived += Display;
        Display();
    }

    public void Display()
    {
        _orderCloud.UpdateProcess(_order.dishCountInOrder);
    }
}
