using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected const string IDLE_ANIMATION = "Idle";
    protected const string WALK_ANIMATION = "Walk";

    [SerializeField] protected NavMeshAgent _navMeshAgent;

    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _angularSpeed = 120f;
    [SerializeField] protected float _stopDistance = 0.5f;

    [SerializeField] protected Animator _animator;

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
