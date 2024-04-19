using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HobData
{
    [SerializeField] private int _serialNumberUponPurchase;

    [SerializeField] private int _maxNumberOfJobsLvl;
    [SerializeField] private int _maxCostOfDishLvl;
    [SerializeField] private int _maxCookingDurationLvl;

    [SerializeField] private int _costOfDishLvl;
    [SerializeField] private int _cookingDurationLvl;
    [SerializeField] private int _numberOfJobsLvl;

    [SerializeField] private double _costOfDish;
    [SerializeField] private double _cookingDuration;
    [SerializeField] private int _currentNumberOfJobs;

    public int CostOfDishLvl
    {
        get { return _costOfDishLvl; }
        set
        {
            if (value <= _maxCostOfDishLvl)
            {
                _costOfDishLvl = value;
                _costOfDish = DishCostCalculator.GetCost(_serialNumberUponPurchase, _costOfDishLvl);
                OnCostOfDishLvlChange?.Invoke();
            }
        }
    }
    public int CookingDurationLvl
    {
        get { return _cookingDurationLvl; }
        set
        {
            if (value <= MaxCookingDurationLvl)
            {
                _cookingDurationLvl = value;
                _cookingDuration = CookingDurationCalculator.GetDuration(_serialNumberUponPurchase, _cookingDurationLvl);
                OnCookingDurationLvlChange?.Invoke();
            }
        }
    }
    public int NumberOfJobsLvl
    {
        get { return _numberOfJobsLvl; }
        set
        {
            if (value <= MaxNumberOfJobsLvl)
            {
                _numberOfJobsLvl = value;
                _currentNumberOfJobs = _numberOfJobsLvl;
                OnNumberOfJobsLvlChange?.Invoke();
            }
        }
    }

    public double CostOfDish => _costOfDish;
    public double CookingDuration => _cookingDuration;
    public int CurrentNumberOfJobs => _currentNumberOfJobs;

    public int MaxCostOfDishLvl => _maxCostOfDishLvl;
    public int MaxCookingDurationLvl => _maxCookingDurationLvl;
    public int MaxNumberOfJobsLvl => _maxNumberOfJobsLvl;

    public double UpgradingCostDishCost =>
        UpgradingCostDishCostCalculator.GetCost(_serialNumberUponPurchase, CostOfDishLvl);
    public double UpgradingCookingDurationCost =>
        UpgradingCookingDurationCostCalculator.GetCost(_serialNumberUponPurchase, _cookingDurationLvl);
    public double UpgradingNumberOfJobsCost =>
        UpgradingNumberOfJobsCostCalculator.GetCost(_serialNumberUponPurchase, CurrentNumberOfJobs);

    public UnityEvent OnCostOfDishLvlChange;
    public UnityEvent OnCookingDurationLvlChange;
    public UnityEvent OnNumberOfJobsLvlChange;

    public void Initialize(int serialNumberUponPurchase, int maxCostOfDishLvl, int maxCookingDurationLvl, int maxNumberOfJobs)
    {
        _serialNumberUponPurchase = serialNumberUponPurchase;

        _maxCostOfDishLvl = maxCostOfDishLvl;
        _maxCookingDurationLvl = maxCookingDurationLvl;
        _maxNumberOfJobsLvl = maxNumberOfJobs;

        CostOfDishLvl = 1;
        CookingDurationLvl = 1;
        NumberOfJobsLvl = 1;
    }
}