using System;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableCharacterPosition _waiterPosition;
    [SerializeField] private List<TableCharacterPosition> _visitorPositions;

    public TableCharacterPosition WaiterPosition => _waiterPosition;
    public List<TableCharacterPosition> VisitorPositions => _visitorPositions;

}