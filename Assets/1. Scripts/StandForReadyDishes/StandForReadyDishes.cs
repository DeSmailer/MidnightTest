using System.Collections.Generic;
using UnityEngine;

public class StandForReadyDishes : MonoBehaviour
{
    [SerializeField] private List<ReadyDishPosition> _readyDishPositions;

    public ReadyDishPosition GetPosition()
    {
        int randomIndex = Random.Range(0, _readyDishPositions.Count);
        return _readyDishPositions[randomIndex];
    }
}
