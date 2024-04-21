using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorsManager : MonoBehaviour
{
    [SerializeField] private Visitor _visitorPrefab;
    [SerializeField] private Transform _visitorSpawnPosition;
    [SerializeField] private List<TableBuyer> _tableBuyers;

    [SerializeField] private List<Table> _availableTables = new List<Table>();
    private int _numberOfVisitors;

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
        _numberOfVisitors += table.VisitorPositions.Count;
        _availableTables.Add(table);

        SpawnVisitor();
    }

    public void SpawnVisitor()
    {
        Visitor visitor = Instantiate(_visitorPrefab, _visitorSpawnPosition.position, _visitorSpawnPosition.rotation);
        foreach (Table table in _availableTables)
        {
            foreach (TableCharacterPosition characterPosition in table.VisitorPositions)
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
        foreach (TableBuyer tableBuyer in _tableBuyers)
        {
            tableBuyer.OnPurchase -= TablePurchaseHandler;
        }
    }
}
