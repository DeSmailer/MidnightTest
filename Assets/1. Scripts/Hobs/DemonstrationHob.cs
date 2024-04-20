using UnityEngine;

public class DemonstrationHob : MonoBehaviour
{
    [SerializeField] private Transform _dishPosition;

    public void Initialize(GameObject dishModel)
    {
        Instantiate(dishModel, _dishPosition.position, _dishPosition.rotation, _dishPosition);
    }
}
