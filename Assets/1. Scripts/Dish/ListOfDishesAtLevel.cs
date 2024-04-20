using System.Collections.Generic;
using UnityEngine;

public class ListOfDishesAtLevel : MonoBehaviour
{
    [SerializeField] private List<DishOnLevelSO> _dishsOnLevelSO;
    private List<DishOnLevel> _dishsOnLevel;

    //[SerializeField] private List<MainHob> _mainHobs;

    public List<DishOnLevel> DishsOnLevel => _dishsOnLevel;

    public void Initialize()
    {
        _dishsOnLevel = new List<DishOnLevel>();
        foreach (DishOnLevelSO item in _dishsOnLevelSO)
        {
            _dishsOnLevel.Add(item.GetDishOnLevel());
        }
    }
}
