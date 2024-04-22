using UnityEngine;

public class ReadyDishPosition : MonoBehaviour
{
    public Transform movePosition;

    public void Put(CookedDish cookedDish)
    {
        cookedDish.transform.parent = transform;
        cookedDish.transform.position = transform.position;
    }
}
