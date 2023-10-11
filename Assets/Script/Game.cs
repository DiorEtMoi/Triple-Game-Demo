using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public List<Food> foods = new List<Food>();

    public int sizeStack = 7;

    public List<PerFapObWithType> perfapsOb = new List<PerFapObWithType> ();

    public Dictionary<FoodType, PerFapObWithType> dict = new Dictionary<FoodType, PerFapObWithType> ();
    public Game_UI ui;
    public static Game instance;
    public void Awake()
    {
        instance = this;
        LoadDict();
    }
    public void LoadDict()
    {
        foreach(PerFapObWithType gameObject in perfapsOb)
        {
            if (!dict.ContainsKey(gameObject.Type))
            {
                dict.Add(gameObject.Type, gameObject);
            }
        }
    }
    
    public void CheckFood()
    {
        
        for(int i = 0;i < foods.Count; i++)
        {
            int count = 0;
            for (int j = 0;j < foods.Count; j++)
            {
                if (foods[i].Type == foods[j].Type)
                {
                    count++;
                    if(count == 3)
                    {
                        removeByType(foods[i].Type,foods);
                        break;
                    }
                }
            }
        }
    }
    public List<Food> removeByType(FoodType type,List<Food> list)
    {
        if (list.Count == 0) { return list; }
        foreach(Food food in list)
        {
            if(food.Type == type)
            {
                list.Remove(food);
                ui.Refresh(list);
                return removeByType(type,list);
            }
        }
        return list;
    }

    public void InsertAFood(Food food)
    {
        int index = -1;
        if(foods.Count == sizeStack)
        {
            Debug.Log("Lose");
            return;
        }
        for(int i = foods.Count - 1; i >= 0; i--)
        {
            if (foods[i].Type == food.Type)
            {
                index = i;
                break;
            }
        }
        if(index == -1)
        {
            foods.Add(food);
            ui.Refresh(foods);
        }
        else
        {
            foods.Insert(index, food);
            ui.Refresh(foods);
        }
        CheckFood();
        
    }
   
    public int IndexInsert(Food food)
    {
        int index = -1;
        if (foods.Count == sizeStack)
        {
            return index;
        }
        for (int i = foods.Count - 1; i >= 0; i--)
        {
            if (foods[i].Type == food.Type)
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
           return foods.Count;
        }
        else
        {
            return index + 1;
        }
    }
    //Stack
    public Stack<Food> CheckSameFood(Stack<Food> stack)
    {
        Stack<Food> temp = new Stack<Food>();
        if(stack.Count < 3) { Debug.Log("Stack not enough food to check"); return stack; }
        
            Food foodType = stack.Pop();
            temp.Push(foodType);
            Food fcheck = stack.Pop();
            temp.Push(fcheck);
            if(foodType.Type == fcheck.Type)
            {
                Food flast = stack.Pop();
                temp.Push(foodType);
                if (foodType.Type == flast.Type)
                {
                    temp.Clear();
                    Debug.Log("Clear");
                    return CheckSameFood(stack);
                }
                else
                {
                    while(temp.Count > 0)
                    {
                    Food food = temp.Pop();
                    stack.Push(food);
                    
                    }
                return stack;   
                }
            }
            else
            {
                while (temp.Count > 0)
                {
                    Food food = temp.Pop();
                    stack.Push(food);
                }
            return stack;
        }
    }
    [System.Serializable]
    public class Food
    {
        public FoodType Type;
    }
    public enum FoodType
    {
        None,
        IceCream,
        Purple,
        Slipper,
        Leaf
    }
    [System.Serializable]
    public class PerFapObWithType
    {
        public FoodType Type;
        public GameObject perfaps;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    

