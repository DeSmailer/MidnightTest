using UnityEngine;

[CreateAssetMenu(fileName = "DishOnLevelSO", menuName = "ScriptableObjects/DishOnLevelSO", order = 1)]
public class DishOnLevelSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _dishModelPrefab;
    [SerializeField] private Sprite _dishSprite;

    public string Name => _name;
    public GameObject DishModelPrefab => _dishModelPrefab;
    public Sprite DishSprite => _dishSprite;

    public DishOnLevel GetDishOnLevel()
    {
        DishOnLevel dishOnLevel = new DishOnLevel(Name, DishModelPrefab, DishSprite);
        return dishOnLevel;
    }
}
