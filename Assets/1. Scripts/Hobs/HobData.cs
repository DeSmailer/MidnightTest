using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HobData
{
    [SerializeField] private int _serialNumberUponPurchase;

    [SerializeField] private double _initCookingDuration;
    [SerializeField] private double _maxNumberOfJobs;

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
            _costOfDishLvl = value;
            _costOfDish = DishCostCalculator.GetCost(_serialNumberUponPurchase, _costOfDishLvl);
            OnCostOfDishLvlChange?.Invoke();
        }
    }
    public int CookingDurationLvl
    {
        get { return _cookingDurationLvl; }
        set
        {
            _cookingDurationLvl = value;
            _cookingDuration = CookingDurationCalculator.GetDuration(_serialNumberUponPurchase, _cookingDurationLvl);
            OnCookingDurationLvlChange?.Invoke();
        }
    }
    public int NumberOfJobsLvl
    {
        get { return _numberOfJobsLvl; }
        set
        {
            _numberOfJobsLvl = value;
            _currentNumberOfJobs = _numberOfJobsLvl;
            OnNumberOfJobsLvlChange?.Invoke();
        }
    }

    public double CostOfDish => _costOfDish;
    public double CookingDuration => _cookingDuration;
    public int CurrentNumberOfJobs => _currentNumberOfJobs;

    public double UpgradingCostDishCost =>
        UpgradingCostDishCostCalculator.GetCost(_serialNumberUponPurchase, CostOfDishLvl);
    public double UpgradingCookingDurationCost =>
        UpgradingCookingDurationCostCalculator.GetCost(_serialNumberUponPurchase, _cookingDurationLvl);
    public double UpgradingNumberOfJobs =>
        UpgradingNumberOfJobsCostCalculator.GetCost(_serialNumberUponPurchase, CurrentNumberOfJobs);

    public UnityEvent OnCostOfDishLvlChange;
    public UnityEvent OnCookingDurationLvlChange;
    public UnityEvent OnNumberOfJobsLvlChange;

    public void Initialize(int serialNumberUponPurchase, int maxNumberOfJobs)
    {
        _serialNumberUponPurchase = serialNumberUponPurchase;
        _maxNumberOfJobs = maxNumberOfJobs;

        CostOfDishLvl = 1;
        CookingDurationLvl = 1;
        NumberOfJobsLvl = 1;
    }
}
