using Constants;
using UnityEngine;
using UnityEngine.UI;

public class PhotoDisplay : MonoBehaviour
{
    [SerializeField] [Tooltip(Tooltips.PhotoDisplayContainer)]
    private Image photoContainer;

    public void Show(Sprite sprite)
    {
        photoContainer.sprite = sprite;
        photoContainer.preserveAspect = true;
        gameObject.SetActive(true);
    }
}