using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : Character
{
    private Table _table;

    [SerializeField] private WaiterState _currentState;
    [SerializeField] private TablesWaitingForWaiter _tablesWaitingForWaiter;

    private bool _isBusy = false;

    public void Initialize(TablesWaitingForWaiter tablesWaitingForWaiter)
    {
        base.Initialize();

        _tablesWaitingForWaiter = tablesWaitingForWaiter;
        _currentState = WaiterState.Idle;

        _tablesWaitingForWaiter.OnAddedToWaitingList.AddListener(FindJob);

        FindJob();
    }

    public void FindJob()
    {
        if (_isBusy == true || gameObject.activeSelf == false)
        {
            return;
        }

        Table table = _tablesWaitingForWaiter.GatTable();
        if (table != null)
        {
            _isBusy = true;

            _table = table;
            _tablesWaitingForWaiter.RemoveTableFromWaitingList(_table);

            GoTo(_table.WaiterPositions.position);
            _table.WaiterPositions.State = CharacterPositionState.Taken;

            _currentState = WaiterState.MoveToTable;
        }
    }

    private void Update()
    {
        switch (_currentState)
        {
            case WaiterState.Idle:
                break;
            case WaiterState.MoveToTable:
                RotateToPosition(_table.WaiterPositions.position, WaiterState.TakesOrder);
                break;
            case WaiterState.TakesOrder:
                break;
            case WaiterState.GoesRorDish:
                break;
            case WaiterState.TakesTheDish:
                break;
            default:
                break;
        }
    }

    private void RotateToPosition(Transform newTransform, WaiterState newState)
    {
        if (Vector3.Distance(newTransform.position, transform.position) <= _stopDistance)
        {
            _navMeshAgent.isStopped = true;

            transform.position = Vector3.MoveTowards(transform.position, newTransform.position, _speed * Time.deltaTime);

            Quaternion targetRotation = newTransform.rotation;
            if (targetRotation != transform.rotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
            }
            else
            {
                _currentState = newState;
                //_characterPosition.State = CharacterPositionState.Waiting;
            }
        }
    }
}

public enum WaiterState
{
    Idle,
    MoveToTable,
    TakesOrder,
    GoesRorDish,
    TakesTheDish
}
