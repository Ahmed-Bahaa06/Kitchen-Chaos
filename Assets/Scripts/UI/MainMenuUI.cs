using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        Time.timeScale = 1f;
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    private void OnPlayButtonClicked()
    {        
        Loader.Load(Loader.Scene.GameScene);
    }
}
