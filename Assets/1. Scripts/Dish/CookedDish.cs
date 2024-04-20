using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedDish : MonoBehaviour
{
    [SerializeField] private Transform _dishModelPosition;
    [SerializeField] private DishOnLevel _dishOnLevel;
    [SerializeField] private double _cost;

    public void Initialize(DishOnLevel dishOnLevel, double cost)
    {
        _dishOnLevel = dishOnLevel;
        _cost = cost;

        Instantiate(_dishOnLevel.DishModelPrefab, _dishModelPosition.position, _dishModelPosition.rotation, _dishModelPosition);
    }
}
