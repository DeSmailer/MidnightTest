using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterManager : MonoBehaviour
{
    [SerializeField] private Waiter _waiterPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private List<TableBuyer> _tableBuyers;

    [SerializeField] private List<Table> _availableTables = new List<Table>();
    [SerializeField] private List<Waiter> _waiters;
    private int _numberOfWaiters;

    public void Initialize(List<TableBuyer> tableBuyers)
    {
        _tableBuyers = tableBuyers;
        foreach (TableBuyer tableBuyer in _tableBuyers)
        {
            tableBuyer.OnPurchase += TablePurchaseHandler;
        }
    }

    private void TablePurchaseHandler(Table table)
    {
        _numberOfWaiters++;
        _availableTables.Add(table);

        SpawnWaiter();
    }

    public void SpawnWaiter()
    {
        Waiter waiter = Instantiate(_waiterPrefab, _spawnPosition.position, _spawnPosition.rotation);
        _waiters.Add(waiter);
    }

    private void OnDestroy()
    {
        foreach (TableBuyer tableBuyer in _tableBuyers)
        {
            tableBuyer.OnPurchase -= TablePurchaseHandler;
        }
    }
}
