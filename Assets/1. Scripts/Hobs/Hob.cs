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
    [SerializeField] private HobState _currentState;

    public HobState CurrentState
    {
        get { return _currentState; }
        set
        {
            _currentState = value;
            OnStateChange?.Invoke(this);
        }
    }

    public Action<Hob> OnStateChange;
}

public enum HobState
{
    Free,
    Taken
}


