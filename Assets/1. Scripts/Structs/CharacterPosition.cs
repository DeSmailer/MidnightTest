using System;
using UnityEngine;

[Serializable]
public class CharacterPosition
{
    public Transform position;
    private CharacterPositionState _state;

    public CharacterPositionState State
    {
        get { return _state; }
        set
        {
            _state = value;
            OnStateCange?.Invoke(this);
        }
    }

    public Action<CharacterPosition> OnStateCange;
}
