using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _aboutButton;


    private void Awake()
    {
        _playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainScene);
        });
        _quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    
}
