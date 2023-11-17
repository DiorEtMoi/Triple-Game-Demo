using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        resumeBtn.onClick.AddListener(() =>
        {
            FoodGameManager.instance.PausedGame();
        });
        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private void Start()
    {
        FoodGameManager.instance.OnGamePaused += Instance_OnGamePaused;
        Hide();
    }

    private void Instance_OnGamePaused(object sender, FoodGameManager.OnPauseGameParam e)
    {
        if(e.isPaused)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
