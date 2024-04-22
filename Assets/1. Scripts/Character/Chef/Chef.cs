using System;
using System.Collections.Generic;
using UnityEngine;

public class Chef : Character
{
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private DishesForCooking _dishesForCooking;

    private Hob _hob;

    [SerializeField] private ChefState _currentState;

    [SerializeField] private ProgressBar _progressBar;

    private bool _isBusy = false;

    //private void Start()
    //{
    //    _animator.Play(IDLE_ANIMATION);
    //}

    public void Initialize(DishesForCooking dishesForCooking, List<MainHob> mainHobs)
    {
        base.Initialize();
        _progressBar.Toggle(false);

        _mainHobs = mainHobs;
        _dishesForCooking = dishesForCooking;

        _currentState = ChefState.Idle;
        foreach (MainHob mainHob in _mainHobs)
        {
            foreach (Hob hob in mainHob.Hobs)
            {
                hob.OnStateChange += FindJob;
            }
        }
        _dishesForCooking.OnAdded.AddListener(FindJob);
        //FindJob();
    }


    public void FindJob()
    {
        if (_isBusy == true || gameObject.activeSelf == false)
        {
            return;
        }
        if (FindJobTakesDish(0) == false)
            return;
        //FindJobGoesForDish();

    }

    public bool FindJobTakesDish(int index)
    {
        Debug.Log(index);
        Debug.Log(_dishesForCooking.Dishes.Count);
        if (index >= _dishesForCooking.Dishes.Count)
        {
            Debug.Log(false);
            return false;
        }

        DishInOrder dishInOrder = _dishesForCooking.GetFromList(index);
        Debug.Log(dishInOrder);
        if (dishInOrder != null)
        {
            foreach (MainHob mainHob in _mainHobs)
            {
                Debug.Log(mainHob);
                if (mainHob.DishOnLevel == dishInOrder.dish)
                {
                    Hob hob = mainHob.GetFreeHob();
                    Debug.Log(hob);
                    if (hob == null)
                    {
                        Debug.Log("++");
                        index++;
                        FindJobTakesDish(index);
                    }
                    else
                    {
                        Debug.Log("else");
                        _hob = hob;
                        _hob.CurrentState = HobState.Taken;
                        GoTo(_hob.HobCharacterPosition.position);
                        _currentState = ChefState.MoveToHob;
                        _isBusy = true;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case ChefState.Idle:
                _animator.Play(IDLE_ANIMATION);
                break;
            case ChefState.MoveToHob:
                RotateToPosition(_hob.HobCharacterPosition.position, ChefState.Cooking /*, TryTakesOrder*/);
                _animator.Play(WALK_ANIMATION);
                break;
            case ChefState.Cooking:
                _animator.Play(IDLE_ANIMATION);
                break;
            case ChefState.CarriesDish:
                _animator.Play(WALK_ANIMATION);
                break;
            default:
                break;
        }
    }

    //private void TryTakesOrder()
    //{
    //    foreach (TableCharacterPosition item in _table.VisitorPositions)
    //    {
    //        Visitor character = (Visitor)item.character;
    //        if (item.State == CharacterPositionState.Waiting && character.Order == null)
    //        {
    //            StartCoroutine(TakesOrder(_orderCreationTime, character));
    //            return;
    //        }
    //    }
    //    FindJobTakesOrder();
    //}

    //private IEnumerator TakesOrder(float orderCreationTime, Visitor visitor)
    //{
    //    _progressBar.Toggle(true);
    //    float duration = orderCreationTime;
    //    while (duration > 0)
    //    {
    //        yield return null;
    //        duration -= Time.deltaTime;
    //        _progressBar.UpdateProcessUI(duration, orderCreationTime);
    //    }
    //    _progressBar.Toggle(false);

    //    DishCountInOrder dishCountInOrder = _listOfDishesAtLevel.GetRandomDishCountInOrder();
    //    Order order = new Order(dishCountInOrder, visitor.Table, visitor);
    //    visitor.Order = order;
    //    _orderManager.AddOrder(order);
    //    TryTakesOrder();
    //}

    private void RotateToPosition(Transform newTransform, ChefState newState, Action action = null)
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

public enum ChefState
{
    Idle,
    MoveToHob,
    Cooking,
    CarriesDish
}
