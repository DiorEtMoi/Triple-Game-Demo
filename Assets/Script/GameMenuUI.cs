using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;

    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
