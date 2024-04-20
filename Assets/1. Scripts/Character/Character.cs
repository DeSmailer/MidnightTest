using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _navMeshAgent;

    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _angularSpeed = 120f;
    [SerializeField] protected float _stopDistance = 0.5f;

    [SerializeField] private Animator _animator;

    protected virtual void GoTo(Transform position)
    {
        _navMeshAgent.SetDestination(position.position);
    }

    public virtual void Initialize()
    {
        _navMeshAgent.speed = _speed;
        _navMeshAgent.angularSpeed = _angularSpeed;
        _navMeshAgent.stoppingDistance = _stopDistance;
    }
}
