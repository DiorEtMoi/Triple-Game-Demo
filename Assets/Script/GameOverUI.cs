using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button playAgainBtn;
    [SerializeField] private Button Quit;

    private void Awake()
    {
        playAgainBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        Quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        FoodGameManager.instance.OnGameOver += Instance_OnGameOver;
        Hide();
    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        FoodGameManager.instance.OnGameOver -= Instance_OnGameOver;

    }
}
