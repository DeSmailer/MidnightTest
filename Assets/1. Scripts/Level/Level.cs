using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private ListOfDishesAtLevel _listOfDishes;

    private void Start()
    {
        _listOfDishes.Initialize();
        InitializeMainHobs();
    }

    public void InitializeMainHobs()
    {
        for (int i = 0; i < _mainHobs.Count; i++)
        {
            _mainHobs[i].Initialize(_listOfDishes.DishsOnLevel[i]);
        }
    }
}
