using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Visitor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private CharacterPosition _characterPosition;
    [SerializeField] private Transform _tablePosition;
    [SerializeField] private Transform _leavePosition;

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _angularSpeed = 120f;
    [SerializeField] private float _stopDistance;

    [SerializeField] private VisitorState _currentState;

    [SerializeField] private Animator _animator;

    public void Initialize(CharacterPosition characterPosition, Transform leavePosition)
    {
        _characterPosition = characterPosition;
        _tablePosition = characterPosition.position;

        _leavePosition = leavePosition;

        _navMeshAgent.speed = _speed;

        GoTo(_tablePosition);
        _currentState = VisitorState.MoveToTable;
    }

    private void GoTo(Transform position)
    {
        _navMeshAgent.SetDestination(position.position);
    }

    private void Update()
    {
        switch (_currentState)
        {
            case VisitorState.MoveToTable:
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
                        _currentState = VisitorState.Stand;
                    }
                }
                break;
            case VisitorState.Stand:
                break;
            case VisitorState.Leave:
                break;
            default:
                break;
        }
    }
}

public enum VisitorState
{
    MoveToTable,
    Stand,
    Leave,
}
