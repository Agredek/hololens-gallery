using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneManagers
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        [SerializeField] private Slider perPageSlider;
    
        public void OpenGallery()
        {
            PlayerPrefs.SetFloat(SceneManagementConstants.PerPageKey, perPageSlider.value);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManagementConstants.GallerySceneIndex);
        }
    }
}