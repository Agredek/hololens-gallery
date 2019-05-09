using Constants;
using UnityEngine;
using UnityEngine.UI;
using Utils;

[RequireComponent(typeof(Image))]
public class Photo : MonoBehaviour
{
    [SerializeField] [Tooltip(Tooltips.Photo)]
    private Image photo;

    [SerializeField] private BoxCollider boxCollider;

    private void Start()
    {
        var cellSize = Global.Instance.contentGrid.cellSize;
        boxCollider.size = new Vector3(cellSize.x, cellSize.y, boxCollider.size.z);
    }

    public void SetPhoto(Texture2D texture)
    {
        photo.sprite = texture.ToSprite();
        photo.preserveAspect = true;
        photo.enabled = true;
    }

    public void Disable()
    {
        photo.enabled = false;
    }

    public void Enlarge()
    {
        Global.Instance.display.Show(photo.sprite);
    }
}