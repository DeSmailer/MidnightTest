using System;
using UnityEngine;

[Serializable]
public class TableCharacterPosition
{
    public Table table;
    public Transform position;
    private CharacterPositionState _state;

    public CharacterPositionState State
    {
        get { return _state; }
        set
        {
            _state = value;
            Debug.Log(_state.ToString());
            OnStateCange?.Invoke(this, _state);
        }
    }

    public Action<TableCharacterPosition, CharacterPositionState> OnStateCange;
}
