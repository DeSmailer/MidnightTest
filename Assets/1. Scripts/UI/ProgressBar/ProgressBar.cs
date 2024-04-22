using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void UpdateProcessUI(float timeLeft, float totalProcess)
    {
        float t = totalProcess - timeLeft;
        if (_image != null)
        {
            _image.fillAmount = t / totalProcess;
        }
    }

    public void Toggle(bool result)
    {
        gameObject.SetActive(result);

        _image.fillAmount = 0;
    }
}
