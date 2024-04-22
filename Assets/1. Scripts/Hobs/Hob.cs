using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hob : MonoBehaviour
{
    /*
     * ������� ������ ���� ������� ����� ����������� ��������� ������
     * ����� ������� �����, ���� ����� ��� �����������, �� ������� ��� �� ������ (���������� � ��������� ������)
     * ������� � ������ �� ������ ���������� � ������ ������� ����
     * 
     *��������� ���� ������ �� ����� ������� ����� ��������
     *���������������� ������� ����� �������
     *� ������ ���������� ������� ���� ����� � ���������� ���� �� ������
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


