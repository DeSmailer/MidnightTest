using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHobSurface : MonoBehaviour
{
   
    ///указано что мы готовим, сколько это стоит, сколько открыто рабочих поверхностей

    private GameObject _foodPrefab;
    private Transform[] _hobSurfacesPositions;

    public void Initialize(Transform myPosition, Transform[] hobSurfacesPositions, GameObject foodPrefab, HobSurface hobSurfacePrefab)
    {
        _foodPrefab = foodPrefab;
        _hobSurfacesPositions = hobSurfacesPositions;
    }
}
