using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderCloud : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _countText;

    public void UpdateProcess(DishCountInOrder dishCountInOrder)
    {
        _image.sprite = dishCountInOrder.dish.DishImage;
        _countText.text = dishCountInOrder.count.ToString();
    }

    public void Toggle(bool result)
    {
        gameObject.SetActive(result);

        _image.fillAmount = 0;
    }
}
