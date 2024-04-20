using System;
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
    public bool IsPurchased
    {
        get { return _isPurchased; }
        set
        {
            if (_isPurchased == false && value == true)
            {
                _isPurchased = value;
                OnPurchased?.Invoke(this);
            }
        }
    }

    public Action<DishOnLevel> OnPurchased;


    public DishOnLevel(string name, GameObject dishModelPrefab, Sprite dishImage)
    {
        _name = name;
        _dishModelPrefab = dishModelPrefab;
        _dishImage = dishImage;
    }
}
