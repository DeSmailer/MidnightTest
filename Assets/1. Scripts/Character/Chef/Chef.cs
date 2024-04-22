using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : Character
{
    [SerializeField] private List<MainHob> _mainHobs;
    [SerializeField] private DishesForCooking _dishesForCooking;
    [SerializeField] private StandForReadyDishes _standForReadyDishes;

    [SerializeField] private Transform _hands;
    [SerializeField] private CookedDish _cookedDishPrefab;

    private Hob _hob;
    private DishInOrder _dishInOrder;
    private CookedDish _cookedDish;
    [SerializeField] private Transform _readyDishPosition;

    [SerializeField] private ChefState _currentState;

    [SerializeField] private ProgressBar _progressBar;

    private bool _isBusy = false;

    //private void Start()
    //{
    //    _animator.Play(IDLE_ANIMATION);
    //}

    public void Initialize(DishesForCooking dishesForCooking, List<MainHob> mainHobs, StandForReadyDishes standForReadyDishes)
    {
        base.Initialize();
        _progressBar.Toggle(false);

        _mainHobs = mainHobs;
        _dishesForCooking = dishesForCooking;
        _standForReadyDishes = standForReadyDishes;

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
        if (index >= _dishesForCooking.Dishes.Count)
        {
            return false;
        }

        DishInOrder dishInOrder = _dishesForCooking.GetFromList(index);
        if (dishInOrder != null)
        {
            foreach (MainHob mainHob in _mainHobs)
            {
                if (mainHob.DishOnLevel == dishInOrder.dish)
                {
                    Hob hob = mainHob.GetFreeHob();
                    if (hob == null)
                    {
                        index++;
                        FindJobTakesDish(index);
                    }
                    else
                    {
                        _hob = hob;
                        _dishInOrder = dishInOrder;
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
                RotateToPosition(_hob.HobCharacterPosition.position, ChefState.Cooking, Cook);
                _animator.Play(WALK_ANIMATION);
                break;
            case ChefState.Cooking:
                _animator.Play(IDLE_ANIMATION);
                break;
            case ChefState.CarriesDish:
                RotateToPosition(_readyDishPosition, ChefState.Idle, FindJob);
                _animator.Play(WALK_ANIMATION);
                break;
            default:
                break;
        }
    }

    private void Cook()
    {
        _currentState = ChefState.Cooking;
        StartCoroutine(CookDish());

        //FindJobTakesOrder();
    }

    private IEnumerator CookDish()
    {
        _progressBar.Toggle(true);
        float dishCreationTime = (float)_hob.MainHob.HobData.CookingDuration;
        float duration = dishCreationTime;
        Debug.Log("dishCreationTime " + dishCreationTime);
        Debug.Log("duration1 " + duration);
        while (duration > 0)
        {
            yield return null;
            duration -= Time.deltaTime;
            Debug.Log("duration2 " + duration);
            _progressBar.UpdateProcessUI(duration, dishCreationTime);
        }
        _progressBar.Toggle(false);

        _cookedDish = Instantiate(_cookedDishPrefab, _hands.position, Quaternion.identity, _hands);
        _cookedDish.Initialize(_dishInOrder, _hob.MainHob.HobData.CostOfDish);


        _hob.CurrentState = HobState.Free;
        //  GoTo(_hob.HobCharacterPosition.position);
        _hob = null;
        _dishInOrder = null;

        _readyDishPosition = _standForReadyDishes.GetPosition();
        GoTo(_readyDishPosition);
        _currentState = ChefState.CarriesDish;
    }

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
