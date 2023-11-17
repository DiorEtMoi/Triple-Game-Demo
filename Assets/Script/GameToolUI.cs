using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameToolUI : MonoBehaviour
{
    [SerializeField] private Button undoBtn;

    private void Awake()
    {
        undoBtn.onClick.AddListener(() =>
        {
            FoodDelivery.instance.UndoObjectInList();
        });
    }
}
