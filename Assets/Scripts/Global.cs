using Constants;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    [Tooltip(Tooltips.PhotoDisplay)] public PhotoDisplay display;

    [Tooltip(Tooltips.ContentGrid)] public GridLayoutGroup contentGrid;

    public Sprite errorImage;

    private static Global instance;
    public float perPage;

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
        perPage = PlayerPrefs.GetFloat(SceneManagementConstants.PerPageKey, 10);
    }

    private static void Initialize()
    {
        if (instance == null)
            instance = FindObjectOfType<Global>();
    }
}