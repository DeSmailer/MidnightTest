using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TablesWaitingForWaiter : MonoBehaviour
{
    [SerializeField] private List<Table> _tables;
    [SerializeField] private HashSet<Table> _waitingTables;

    public HashSet<Table> WaitingTables => _waitingTables;

    public UnityEvent OnAddedToWaitingList;

    public void Initialize(List<Table> tables)
    {
        _tables = tables;
        SubscribeOnEvents();
    }

    public void SubscribeOnEvents()
    {
        _waitingTables = new HashSet<Table>();
        foreach (Table table in _tables)
        {
            foreach (TableCharacterPosition characterPosition in table.VisitorPositions)
            {
                characterPosition.OnStateCange += TryAddTableToWaitingList;
                Debug.Log("TryAddTableToWaitingList");
            }
        }
    }

    public void TryAddTableToWaitingList(TableCharacterPosition characterPosition, CharacterPositionState state)
    {
        if (state == CharacterPositionState.Waiting)
        {
            _waitingTables.Add(characterPosition.table);
            OnAddedToWaitingList?.Invoke();
        }
    }

    public Table GatTable()
    {
        if (WaitingTables.Count > 0)
        {
            return WaitingTables.FirstOrDefault();
        }
        else
        {
            return null;
        }
    }


    public void RemoveTableFromWaitingList(Table table)
    {
        _waitingTables.Remove(table);

    }
}
