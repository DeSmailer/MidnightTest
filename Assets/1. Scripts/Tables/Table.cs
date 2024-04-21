using System;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableCharacterPosition _waiterPositions;
    [SerializeField] private List<TableCharacterPosition> _visitorPositions;

    public TableCharacterPosition WaiterPositions => _waiterPositions;
    public List<TableCharacterPosition> VisitorPositions => _visitorPositions;

}