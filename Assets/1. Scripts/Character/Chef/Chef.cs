using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : Character
{
    private void Start()
    {
        _animator.Play(IDLE_ANIMATION);
    }
}

public enum ChefState
{
    Idle,
    MoveToHobe,
    Cooking,
    CarriesDish
}
