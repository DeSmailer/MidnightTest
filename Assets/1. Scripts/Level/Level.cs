using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private ShoppingList _shoppingList;
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private List<Table> _tables;
    [SerializeField] private List<TableBuyer> _tableBuyers;
    [SerializeField] private ListOfDishesAtLevel _listOfDishes;
    [SerializeField] private VisitorsManager _visitorsManager;
    [SerializeField] private TablesWaitingForWaiter _tablesWaitingForWaiter;

    private void Start()
    {
        _shoppingList.Initialize();

        _listOfDishes.Initialize();

        InitializeMainHobs();
        _visitorsManager.Initialize(_tableBuyers);
        _tablesWaitingForWaiter.Initialize(_tables);

        StartCoroutine(Test());
    }

    public void InitializeMainHobs()
    {
        for (int i = 0; i < _mainHobs.Count; i++)
        {
            _mainHobs[i].Initialize(_listOfDishes.DishsOnLevel[i]);
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
