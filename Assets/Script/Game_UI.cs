using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_UI : MonoBehaviour
{
    public Game game;
    public static Game_UI instance;
    public List<Slot_UI> slot;
    public bool isMoving = false;
    public GameObject losePanel;

    public void Awake()
    {
        instance = this; 
    }
    public void Refresh(List<Game.Food> foods)
    {   
      for(int i = 0; i < slot.Count; i++)
        {
            if(i >= foods.Count)
            {
                slot[i].setUI(Game.FoodType.None);
            }
            else
            {
                slot[i].setUI(foods[i].Type);
            }
        }
    }
    public void AddToList(Food_UI f)
    {
        if(isMoving == false)
        {
            isMoving = true;
            int index = game.IndexInsert(new Game.Food { Type = f.type });
            if(index < 0)
            {
                losePanel.SetActive(true);

            }
            else
            {
                f.transform.DOMove(slot[index].transform.position, 0.4f).OnComplete(() =>
                {
                    f.gameObject.SetActive(false);
                    game.InsertAFood(new Game.Food { Type = f.type });
                    isMoving = false;
                });
            }
            Debug.Log(index);
        }
    }
}
