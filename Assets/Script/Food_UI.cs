using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_UI : MonoBehaviour
{
    public Game.FoodType type;
    public Game_UI ui;
    public void Awake()
    {
        ui = GameObject.FindWithTag("Game_UI").GetComponent<Game_UI>();
    }
    public void OnMouseUpAsButton()
    {
        ui.AddToList(this);
    }
    
   
}
