using Constants;
using UnityEngine;
using Utils;

[RequireComponent(typeof(SpriteRenderer))]
public class Photo : MonoBehaviour
{
    [SerializeField] [Tooltip(Tooltips.Photo)]
    private SpriteRenderer photo;

    public void SetPhoto(Texture2D texture)
    {
        transform.localScale *= 15;
        photo.sprite = texture.ToSprite();
    }
}