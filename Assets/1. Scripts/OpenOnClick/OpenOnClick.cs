using UnityEngine;

public abstract class OpenOnClick : MonoBehaviour
{
    public abstract void Open();

    private void OnMouseDown()
    {
        Open();
    }
}


