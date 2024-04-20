using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : Character
{
    [SerializeField] private CharacterPosition _characterPosition;

    [SerializeField] private WaiterState _currentState;

    [SerializeField] private Animator _animator;

    public override void Initialize()
    {
        base.Initialize();

        //_characterPosition = characterPosition;

        _currentState = WaiterState.Idle;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case WaiterState.Idle:
                break;
            case WaiterState.MoveToTable:
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

    private void RotateToTable()
    {
        //if (Vector3.Distance(_tablePosition.position, transform.position) <= _stopDistance)
        //{
        //    _navMeshAgent.isStopped = true;

        //    transform.position = Vector3.MoveTowards(transform.position, _tablePosition.position, _speed * Time.deltaTime);

        //    Quaternion targetRotation = _tablePosition.rotation;
        //    if (targetRotation != transform.rotation)
        //    {
        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
        //    }
        //    else
        //    {
        //        _currentState = VisitorState.Stand;
        //        _characterPosition.State = CharacterPositionState.Waiting;
        //    }
        //}
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
