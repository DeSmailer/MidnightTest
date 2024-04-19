using UnityEngine;

public class MainHob : MonoBehaviour, IPurchased
{
    //[SerializeField] private const int LEVELS_PER_HOB = 25;

    [SerializeField] private string _name;
    [Range(1, 10)] [SerializeField] private int _serialNumberUponPurchase;

    [SerializeField] private int _maxCostOfDishLvl = 1;
    [SerializeField] private int _maxCookingDurationLvl = 1;

    [SerializeField] private HobData _hobData;
    [SerializeField] private DemonstrationHob _demonstrationHob;
    [SerializeField] private Hob[] _hobs;

    [SerializeField] protected bool _isPurchased;

    public string Name => _name;
    public double Price => HobCostCalculator.GetCost(_serialNumberUponPurchase);
    public bool IsPurchased => _isPurchased;
    public HobData HobData => _hobData;

    private void Start()
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
        _hobs[0].gameObject.SetActive(true);

        _hobData.Initialize(_serialNumberUponPurchase, _maxCostOfDishLvl, _maxCookingDurationLvl, _hobs.Length);

        _isPurchased = true;
    }
}
