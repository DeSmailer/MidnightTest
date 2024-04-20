using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorsManager : MonoBehaviour
{
    [SerializeField] private Visitor _visitorPrefab;
    [SerializeField] private Transform _visitorSpawnPosition;
    [SerializeField] private List<Table> _tables;
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

        SpawnVisitor();
    }

    public void SpawnVisitor()
    {
        Visitor visitor = Instantiate(_visitorPrefab, _visitorSpawnPosition.position, _visitorSpawnPosition.rotation);
    }

    private void OnDestroy()
    {
        foreach (Table table in _tables)
        {
            table.OnPurchase -= TablePurchaseHandler;
        }
    }
}
