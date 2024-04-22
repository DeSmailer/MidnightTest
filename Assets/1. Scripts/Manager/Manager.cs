using UnityEngine;

public class Manager : MonoBehaviour
{
    private const string IDLE_ANIMATION = "Idle";

    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator.Play(IDLE_ANIMATION);
    }
}
