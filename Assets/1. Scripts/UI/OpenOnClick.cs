using UnityEngine;

public class OpenOnClick : MonoBehaviour
{
    [SerializeField] private GameObject _popUpGO;
    private IPopUp _popUp;

    private void Awake()
    {
        IPopUp popUp = _popUpGO.GetComponent<IPopUp>();
        if (popUp != null)
        {
            _popUp = popUp;
        }
    }

    private void OnMouseDown()
    {
        _popUp.Open();
    }
}
