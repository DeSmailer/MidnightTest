using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hob : MonoBehaviour
{
    /*
     * сделать список блюд которые нужно приготовить конкретно сейчас
     * повар смотрит блюдо, если может его приготовить, то удаляет его из списка (осторожней с сылочными типами)
     * готовит и отдает на стойку прокидывая в список готовых блюд
     * 
     *прокинуть сюда ссылку на блюдо которое можем готовить
     *инициализировать поваров всеми печками
     *в поваре происходит перебор всех печек и выбирается куда он пойдет
     *
     */
    [SerializeField] private MainHob _mainHob;
    [SerializeField] private HobCharacterPosition _characterPosition;

    [SerializeField] private HobState _currentState;

    public HobCharacterPosition HobCharacterPosition => _characterPosition;
    public MainHob MainHob => _mainHob;

    public HobState CurrentState
    {
        get { return _currentState; }
        set
        {
            _currentState = value;
            OnStateChange?.Invoke();
        }
    }

    public Action OnStateChange;

    public void Initialize(MainHob mainHob)
    {
        _mainHob = mainHob;
    }

    //public bool IsFree()
    //{
    //    if (_characterPosition.State == CharacterPositionState.Free)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}

public enum HobState
{
    Free,
    Taken
}


