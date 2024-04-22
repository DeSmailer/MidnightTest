using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedDish : MonoBehaviour
{
    [SerializeField] private Transform _dishModelPosition;
    [SerializeField] private DishInOrder _dishInOrder;
    [SerializeField] private double _cost;

    public void Initialize(DishInOrder dishInOrder, double cost)
    {
        _dishInOrder = dishInOrder;
        _cost = cost;

        Instantiate(_dishInOrder.dish.DishModelPrefab, _dishModelPosition.position, _dishModelPosition.rotation, _dishModelPosition);
    }
}
