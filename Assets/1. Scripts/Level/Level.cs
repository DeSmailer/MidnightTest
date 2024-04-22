using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private ShoppingList _shoppingList;
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private List<Table> _tables;
    [SerializeField] private List<TableBuyer> _tableBuyers;
    [SerializeField] private List<Waiter> _waiters;
    [SerializeField] private List<Chef> _chefs;
    [SerializeField] private ListOfDishesAtLevel _listOfDishes;
    [SerializeField] private VisitorsManager _visitorsManager;
    [SerializeField] private TablesWaitingForWaiter _tablesWaitingForWaiter;
    [SerializeField] private OrderManager _orderManager;
    [SerializeField] private DishesForCooking _dishesForCooking;
    [SerializeField] private StandForReadyDishes _standForReadyDishes;

    private void Start()
    {
        _shoppingList.Initialize();

        _listOfDishes.Initialize();

        InitializeMainHobs();
        _visitorsManager.Initialize(_tableBuyers);
        _tablesWaitingForWaiter.Initialize(_tables);

        InitializeWaiters();
        InitializeChefs();

        //StartCoroutine(Test());
    }

    public void InitializeMainHobs()
    {
        for (int i = 0; i < _mainHobs.Count; i++)
        {
            _mainHobs[i].Initialize(_listOfDishes.DishsOnLevel[i]);
        }
    }

    public void InitializeWaiters()
    {
        for (int i = 0; i < _waiters.Count; i++)
        {
            _waiters[i].Initialize(_tablesWaitingForWaiter, _listOfDishes, _orderManager);
        }
    }

    public void InitializeChefs()
    {
        for (int i = 0; i < _chefs.Count; i++)
        {
            _chefs[i].Initialize(_dishesForCooking, _mainHobs, _standForReadyDishes);
        }
    }

    //private IEnumerator Test()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(2f);

    //        DishOnLevel dishOnLevel = _listOfDishes.GetRandomAvailableDish();
    //        if (dishOnLevel != null)
    //        {
    //            Debug.Log(dishOnLevel.Name);

    //        }
    //    }
    //}
}
