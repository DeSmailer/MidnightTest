using System;
using UnityEngine;

[Serializable]
public class HobCharacterPosition
{
    public Hob hob;
    public Transform position;
    public Character character;

    public CharacterPositionState _state;

    public CharacterPositionState State
    {
        get { return _state; }
        set
        {
            _state = value;
            OnStateCange?.Invoke(this, _state);
        }
    }

    public Action<HobCharacterPosition, CharacterPositionState> OnStateCange;
}
