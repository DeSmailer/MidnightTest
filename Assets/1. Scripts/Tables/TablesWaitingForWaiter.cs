using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TablesWaitingForWaiter : MonoBehaviour
{
    [SerializeField] private List<Table> _tables;
    [SerializeField] private List<Table> _waitingTables;

    public List<Table> WaitingTables => _waitingTables;

    public UnityEvent OnAddedToWaitingList;

    public void Initialize(List<Table> tables)
    {
        _tables = tables;
        SubscribeOnEvents();
    }

    public void SubscribeOnEvents()
    {
        _waitingTables = new List<Table>();
        foreach (Table table in _tables)
        {
            foreach (TableCharacterPosition characterPosition in table.VisitorPositions)
            {
                characterPosition.OnStateCange += TryAddTableToWaitingList;
            }
        }
    }

    public void TryAddTableToWaitingList(TableCharacterPosition characterPosition, CharacterPositionState state)
    {
        if (state == CharacterPositionState.Waiting)
        {
            if (!_waitingTables.Contains(characterPosition.table))
            {
                _waitingTables.Add(characterPosition.table);
                OnAddedToWaitingList?.Invoke();
            }
        }
    }

    public Table GetTable()
    {
        if (WaitingTables.Count > 0)
        {
            return WaitingTables.FirstOrDefault(x => x.WaiterPosition.State != CharacterPositionState.Taken);
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
