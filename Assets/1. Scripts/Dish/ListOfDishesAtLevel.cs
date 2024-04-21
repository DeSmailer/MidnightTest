using System.Collections.Generic;
using UnityEngine;

public class ListOfDishesAtLevel : MonoBehaviour
{
    [SerializeField] private List<DishOnLevelSO> _dishsOnLevelSO;
    [SerializeField] private List<DishOnLevel> _dishsOnLevel = new List<DishOnLevel>();
    private List<DishOnLevel> _availableDishsOnLevel = new List<DishOnLevel>();

    //[SerializeField] private List<MainHob> _mainHobs;

    public List<DishOnLevel> DishsOnLevel => _dishsOnLevel;
    public List<DishOnLevel> AvailableDishsOnLevel => _availableDishsOnLevel;

    public void Initialize()
    {
        foreach (DishOnLevelSO item in _dishsOnLevelSO)
        {
            DishOnLevel dishOnLevel = item.GetDishOnLevel();
            _dishsOnLevel.Add(dishOnLevel);
            dishOnLevel.OnPurchased += AddAvailableDish;
        }
    }

    private void AddAvailableDish(DishOnLevel dishOnLevel)
    {
        _availableDishsOnLevel.Add(dishOnLevel);
    }

    public DishOnLevel GetRandomAvailableDish()
    {
        if (AvailableDishsOnLevel.Count > 0)
        {
            int randomIndex = Random.Range(0, AvailableDishsOnLevel.Count);
            return AvailableDishsOnLevel[randomIndex];
        }
        return null;
    }

    public DishCountInOrder GetRandomDishCountInOrder()
    {
        DishOnLevel availableDish = GetRandomAvailableDish();
        if (availableDish != null)
        {
            int randomIndex = Random.Range(1, 4);

            return new DishCountInOrder(availableDish, randomIndex);
        }
        return null;
    }

    private void OnDestroy()
    {
        foreach (DishOnLevel dishOnLevel in _dishsOnLevel)
        {
            dishOnLevel.OnPurchased -= AddAvailableDish;
        }
    }
}
