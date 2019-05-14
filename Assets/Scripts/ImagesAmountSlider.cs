using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImagesAmountSlider : Slider
{
    [SerializeField] private Gallery gallery;

    public override void OnPointerUp(PointerEventData eventData)
    {
        gallery.UpdateWindow((int) value);
        base.OnPointerUp(eventData);
    }
}