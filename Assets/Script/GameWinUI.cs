using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
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
        FoodGameManager.instance.OnWinGame += Instance_OnWinGame;
        Hide();
    }

    private void Instance_OnWinGame(object sender, System.EventArgs e)
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
        FoodGameManager.instance.OnWinGame -= Instance_OnWinGame;

    }
}
