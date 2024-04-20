using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private List<Table> _tables;
    [SerializeField] private ListOfDishesAtLevel _listOfDishes;
    [SerializeField] private VisitorsManager _visitorsManager;

    private void Start()
    {
        _listOfDishes.Initialize();

        InitializeMainHobs();
        InitializeTables();
        _visitorsManager.Initialize(_tables);

        StartCoroutine(Test());
    }

    public void InitializeMainHobs()
    {
        for (int i = 0; i < _mainHobs.Count; i++)
        {
            _mainHobs[i].Initialize(_listOfDishes.DishsOnLevel[i]);
        }
    }

    public void InitializeTables()
    {
        for (int i = 0; i < _tables.Count; i++)
        {
            _tables[i].Initialize();
        }
    }

    private IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            DishOnLevel dishOnLevel = _listOfDishes.GetRandomAvailableDish();
            if (dishOnLevel != null)
            {
                Debug.Log(dishOnLevel.Name);

            }
        }
    }
}
