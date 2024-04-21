using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Visitor : Character
{
    [SerializeField] private TableCharacterPosition _characterPosition;
    [SerializeField] private Transform _tablePosition;
    [SerializeField] private Transform _leavePosition;

    [SerializeField] private VisitorState _currentState;

    public void Initialize(TableCharacterPosition characterPosition, Transform leavePosition)
    {
        base.Initialize();

        _characterPosition = characterPosition;
        _tablePosition = characterPosition.position;
        _characterPosition.State = CharacterPositionState.Taken;

        _leavePosition = leavePosition;

        GoTo(_tablePosition);
        _currentState = VisitorState.MoveToTable;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case VisitorState.MoveToTable:
                RotateToTable();
                break;
            case VisitorState.Idle:
                break;
            case VisitorState.Leave:
                break;
            default:
                break;
        }
    }

    private void RotateToTable()
    {
        if (Vector3.Distance(_tablePosition.position, transform.position) <= _stopDistance)
        {
            _navMeshAgent.isStopped = true;

            transform.position = Vector3.MoveTowards(transform.position, _tablePosition.position, _speed * Time.deltaTime);

            Quaternion targetRotation = _tablePosition.rotation;
            if (targetRotation != transform.rotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
            }
            else
            {
                _currentState = VisitorState.Idle;
                _characterPosition.State = CharacterPositionState.Waiting;
            }
        }
    }
}

public enum VisitorState
{
    MoveToTable,
    Idle,
    Leave,
}
