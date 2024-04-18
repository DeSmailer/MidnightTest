using UnityEngine;

public abstract class OpenOnClick : MonoBehaviour
{
    //[SerializeField] private GameObject _popUpGO;
    //private IPopUp _popUp;

    //private void Awake()
    //{
    //    IPopUp popUp = _popUpGO.GetComponent<IPopUp>();
    //    if (popUp != null)
    //    {
    //        _popUp = popUp;
    //    }
    //}
    public abstract void Open();

    private void OnMouseDown()
    {
        Open();
    }
}
