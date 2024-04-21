using System;
using System.Collections;
using UnityEngine;

public class Waiter : Character
{
    private Table _table;

    [SerializeField] private WaiterState _currentState;
    private TablesWaitingForWaiter _tablesWaitingForWaiter;
    private ListOfDishesAtLevel _listOfDishesAtLevel;
    private OrderManager _orderManager;

    [SerializeField] private ProgressBar _progressBar;

    private bool _isBusy = false;
    [SerializeField] private float _orderCreationTime = 3f;

    public void Initialize(TablesWaitingForWaiter tablesWaitingForWaiter,
        ListOfDishesAtLevel listOfDishesAtLevel, OrderManager orderManager)
    {
        base.Initialize();

        _progressBar.Toggle(false);

        _tablesWaitingForWaiter = tablesWaitingForWaiter;
        _listOfDishesAtLevel = listOfDishesAtLevel;
        _orderManager = orderManager;

        _currentState = WaiterState.Idle;

        _tablesWaitingForWaiter.OnAddedToWaitingList.AddListener(FindJob);

        FindJob();
    }

    public void FindJob()
    {
        if (_isBusy == true || gameObject.activeSelf == false)
        {
            return;
        }
        if (FindJobTakesOrder() == false)
            FindJobGoesForDish();

    }

    public bool FindJobTakesOrder()
    {
        Table table = _tablesWaitingForWaiter.GetTable();
        if (table != null)
        {
            if (table.WaiterPosition.State == CharacterPositionState.Taken)
                return false;

            _isBusy = true;

            _table = table;
            _tablesWaitingForWaiter.RemoveTableFromWaitingList(_table);

            GoTo(_table.WaiterPosition.position);
            _table.WaiterPosition.State = CharacterPositionState.Taken;

            _currentState = WaiterState.MoveToTable;
            return true;
        }

        return false;
    }

    public bool FindJobGoesForDish()
    {
        return true;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case WaiterState.Idle:
                break;
            case WaiterState.MoveToTable:
                RotateToPosition(_table.WaiterPosition.position, WaiterState.TakesOrder, TryTakesOrder);
                break;
            case WaiterState.TakesOrder:
                break;
            case WaiterState.GoesForDish:
                break;
            case WaiterState.TakesTheDish:
                break;
            default:
                break;
        }
    }

    private void TryTakesOrder()
    {
        foreach (TableCharacterPosition item in _table.VisitorPositions)
        {
            Visitor character = (Visitor)item.character;
            if (item.State == CharacterPositionState.Waiting && character.Order == null)
            {
                StartCoroutine(TakesOrder(_orderCreationTime, character));
                return;
            }
        }
        FindJobTakesOrder();
    }

    private IEnumerator TakesOrder(float orderCreationTime, Visitor visitor)
    {
        _progressBar.Toggle(true);
        float duration = orderCreationTime;
        while (duration > 0)
        {
            yield return null;
            duration -= Time.deltaTime;
            _progressBar.UpdateProcessUI(duration, orderCreationTime);
        }
        _progressBar.Toggle(false);

        DishCountInOrder dishCountInOrder = _listOfDishesAtLevel.GetRandomDishCountInOrder();
        Order order = new Order(dishCountInOrder, visitor.Table, visitor);
        visitor.Order = order;
        _orderManager.AddOrder(order);
        TryTakesOrder();
    }

    private void RotateToPosition(Transform newTransform, WaiterState newState, Action action = null)
    {
        if (Vector3.Distance(newTransform.position, transform.position) <= _stopDistance)
        {
            _navMeshAgent.isStopped = true;

            transform.position = Vector3.MoveTowards(transform.position, newTransform.position, _speed * Time.deltaTime);

            Quaternion targetRotation = newTransform.rotation;
            if (targetRotation != transform.rotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
            }
            else
            {
                _currentState = newState;
                action?.Invoke();
                //_characterPosition.State = CharacterPositionState.Waiting;
            }
        }
    }
}

public enum WaiterState
{
    Idle,
    MoveToTable,
    TakesOrder,
    GoesForDish,
    TakesTheDish
}
