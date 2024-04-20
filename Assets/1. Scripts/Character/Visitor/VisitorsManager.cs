using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorsManager : MonoBehaviour
{
    [SerializeField] private Visitor _visitorPrefab;
    [SerializeField] private Transform _visitorSpawnPosition;
    [SerializeField] private List<Table> _tables;

    [SerializeField] private List<Table> _availableTables = new List<Table>();
    private int _numberOfVisitors;

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
        _numberOfVisitors += table.VisitorPositions.Count;
        _availableTables.Add(table);

        SpawnVisitor();
    }

    public void SpawnVisitor()
    {
        Visitor visitor = Instantiate(_visitorPrefab, _visitorSpawnPosition.position, _visitorSpawnPosition.rotation);
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
    }

    private void OnDestroy()
    {
        foreach (Table table in _tables)
        {
            table.OnPurchase -= TablePurchaseHandler;
        }
    }
}
