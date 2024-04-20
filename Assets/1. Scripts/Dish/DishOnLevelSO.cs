using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DishOnLevelSO", menuName = "ScriptableObjects/DishOnLevelSO", order = 1)]
public class DishOnLevelSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _dishModelPrefab;
    [SerializeField] private Sprite _dishImage;

    public string Name => _name;
    public GameObject DishModelPrefab => _dishModelPrefab;
    public Sprite DishImage => _dishImage;
}
