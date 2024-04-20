using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Visitor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _to;

    public void GO(Transform pos)
    {
        _navMeshAgent.SetDestination(pos.position);
    }
    private void Awake()
    {

    }

    private void Update()
    {

    }
}

public enum VisitorState
{
    Walk,
    Idle,
}
