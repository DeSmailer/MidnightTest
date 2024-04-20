using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

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
