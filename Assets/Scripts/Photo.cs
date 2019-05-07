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
        photo.sprite = texture.ToSprite();
    }
}