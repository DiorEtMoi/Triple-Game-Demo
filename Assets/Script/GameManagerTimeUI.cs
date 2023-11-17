using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerTimeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeUI;

    private void Awake()
    {
        timeUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (timeUI != null)
        {
            timeUI.text = Mathf.Ceil(FoodGameManager.instance.GetTime()).ToString();
        }
    }
}
