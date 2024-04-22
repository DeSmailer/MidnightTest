using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainHob : MonoBehaviour, IPurchased
{
    [Range(1, 10)] [SerializeField] private int _serialNumberUponPurchase;

    [SerializeField] private int _maxCostOfDishLvl = 1;
    [SerializeField] private int _maxCookingDurationLvl = 1;

    [SerializeField] private HobData _hobData;
    [SerializeField] private DishOnLevel _dishOnLevel;
    [SerializeField] private DemonstrationHob _demonstrationHob;
    [SerializeField] private Hob[] _hobs;

    [SerializeField] private List<Hob> _activeHobs = new List<Hob>();

    [SerializeField] protected bool _isPurchased;

    public string Name => _dishOnLevel.Name;
    public double Price => HobCostCalculator.GetCost(_serialNumberUponPurchase);
    public bool IsPurchased => _isPurchased;
    public HobData HobData => _hobData;
    public List<Hob> ActiveHobs => _activeHobs;
    public DishOnLevel DishOnLevel => _dishOnLevel;
    public Hob[] Hobs => _hobs;


    public void Initialize(DishOnLevel dishOnLevel)
    {
        _dishOnLevel = dishOnLevel;
        _demonstrationHob.Initialize(_dishOnLevel.DishModelPrefab);
        foreach (Hob item in _hobs)
        {
            item.Initialize(this);
        }
    }

    public void MakeInactive()
    {
        _demonstrationHob.gameObject.SetActive(false);
        for (int i = 0; i < _hobs.Length; i++)
        {
            _hobs[i].gameObject.SetActive(false);
        }
    }

    public bool CanBuy(CurrencyManager currencyManager)
    {
        if (currencyManager.Currency >= Price)
        {
            return true;
        }
        return false;
    }

    public void Buy(CurrencyManager currencyManager)
    {
        currencyManager.SubtractCurrency(Price);

        _demonstrationHob.gameObject.SetActive(true);

        _hobData.Initialize(_serialNumberUponPurchase, _maxCostOfDishLvl, _maxCookingDurationLvl, _hobs.Length);

        DishOnLevel.IsPurchased = true;
        _isPurchased = true;

        ActivateHobs();
        _hobData.OnNumberOfJobsLvlChange.AddListener(ActivateHobs);
    }

    private void ActivateHobs()
    {


        for (int i = 0; i < HobData.CurrentNumberOfJobs; i++)
        {
            _hobs[i].gameObject.SetActive(true);
            _activeHobs.Add(_hobs[i]);
        }
    }

    public Hob GetFreeHob()
    {
        Hob hob = ActiveHobs.FirstOrDefault(x => x.CurrentState == HobState.Free);
        return hob;
    }
}
