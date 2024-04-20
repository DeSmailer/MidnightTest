using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterManager : MonoBehaviour
{
    [SerializeField] private Waiter _waiterPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private List<Table> _tables;

    [SerializeField] private List<Table> _availableTables = new List<Table>();
    private int _numberOfWaiters;

    public void Initialize(List<Table> tables)
    {
        _tables = tables;
        foreach (Table table in _tables)
        {
            table.OnPurchase += TablePurchaseHandler;
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
        Waiter visitor = Instantiate(_waiterPrefab, _spawnPosition.position, _spawnPosition.rotation);
       
    }

    public void Check()
    {
        foreach (Table table in _availableTables)
        {
            foreach (CharacterPosition characterPosition in table.VisitorPositions)
            {
                if (characterPosition.State == CharacterPositionState.Free)
                {
                    visitor.Initialize(characterPosition, transform);
                    break;
                }
                Debug.Log("break");
            }
        }

        //TODO
    }

    private void OnDestroy()
    {
        foreach (Table table in _tables)
        {
            table.OnPurchase -= TablePurchaseHandler;
        }
    }
}
