using System.Collections.Generic;
using UnityEngine;

public class StandForReadyDishes : MonoBehaviour
{
    [SerializeField] private List<Transform> _transforms;

    public Transform GetPosition()
    {
        int randomIndex = Random.Range(0, _transforms.Count);
        return _transforms[randomIndex];
    }
}
