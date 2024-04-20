using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishOnLevel
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _dishModelPrefab;
    [SerializeField] private Sprite _dishImage;
    [SerializeField] private bool _isPurchased;

    public string Name => _name;
    public GameObject DishModelPrefab => _dishModelPrefab;
    public Sprite DishImage => _dishImage;
    public bool IsPurchased => _isPurchased;

    public DishOnLevel(string name, GameObject dishModelPrefab, Sprite dishImage)
    {
        _name = name;
        _dishModelPrefab = dishModelPrefab;
        _dishImage = dishImage;
    }
}
