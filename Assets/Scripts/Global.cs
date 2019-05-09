using Constants;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    [Tooltip(Tooltips.PhotoDisplay)]
    public PhotoDisplay display;

    [Tooltip("")] public GridLayoutGroup contentGrid;

    public Sprite errorImage;

    private static Global instance;

    public static Global Instance
    {
        get
        {
            Initialize();
            return instance;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private static void Initialize()
    {
        if (instance == null)
            instance = FindObjectOfType<Global>();
    }
}