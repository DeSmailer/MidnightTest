using System;
using UnityEngine;

[Serializable]
public class TableCharacterPosition
{
    public Table table;
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

    public Action<TableCharacterPosition, CharacterPositionState> OnStateCange;
}
