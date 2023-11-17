using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class FoodDelivery : MonoBehaviour
{
    public event EventHandler OnListFoodChanged;
    private int maxItem = 7;

    public static FoodDelivery instance;
    [SerializeField]
    private List<Food> foods;

    private void Awake()
    {
        instance = this;
        foods = new List<Food>();
    }

    public void AddFoodToList(Food food)
    {
        if (!CanAddFoodToList()) return;

        //Find Postion to Add

        int indexItemToAdd = FindPositionToAdd(food);

        if (indexItemToAdd == -1)
        {
            //In List not have samee type food, Add food to list
            Debug.Log(indexItemToAdd);
            foods.Add(food);

            OnListFoodChanged?.Invoke(this, EventArgs.Empty);
            return;
        }
        else
        {
            Debug.Log(indexItemToAdd);
            //insert Item to List depend index found
            foods.Insert(indexItemToAdd, food);

            ListFoodHaveSameType();

            OnListFoodChanged?.Invoke(this, EventArgs.Empty);
        }

    }
    public bool CanAddFoodToList()
    {
       return foods.Count < maxItem;
    }
    public int FindPositionToAdd(Food food)
    {
        if (isFoodsDeliveryEmpty())
        {
            return -1;
        }
        FoodSO foodSOAdd = food.GetFoodSO();
        for (int i = foods.Count - 1; i >= 0; i--) 
        {
            FoodSO foodSOInList = foods[i].GetFoodSO();
            if (foodSOInList.foodType == foodSOAdd.foodType)
            {
                return i;
            }
        }
        return -1;
    }
    private bool isFoodsDeliveryEmpty()
    {
        return foods.Count == 0;
    }
    public void ListFoodHaveSameType()
    {
        //Dictionary Foods 
        Dictionary<Food.FoodType, int> dictFoods = new Dictionary<Food.FoodType, int>();
        foreach(Food food in foods)
        {
            if (dictFoods.ContainsKey(food.GetFoodSO().foodType))
            {
                dictFoods[food.GetFoodSO().foodType]++;
            }
            else
            {
                dictFoods.Add(food.GetFoodSO().foodType, 1);
            }
        }
        foreach (KeyValuePair<Food.FoodType, int> itemInDict in dictFoods)
        {
            //Check in Dict have a food type 3 times
            if(itemInDict.Value == 3)
            {
                RemoveItemByType(itemInDict.Key);

                dictFoods.Clear();

                return;
            }
        }
    }
    public void RemoveItemByType(Food.FoodType foodType)
    {
        if(isFoodsDeliveryEmpty()) { return; }
        for(int i = 0; i < foods.Count; i++)
        {
            if (foods[i].GetFoodSO().foodType == foodType)
            {
                foods.RemoveAt(i);
                RemoveItemByType(foodType);
                return;
            }
        }
    }
    public List<Food> GetListFoodDeliver()
    {
        return foods;
    }
    public int GetMaxItem()
    {
        return maxItem;
    }
    public void UndoObjectInList()
    {
        if (isFoodsDeliveryEmpty()) { Debug.Log("List dont have any food to undo"); return; }

        Food f = foods[foods.Count - 1];

        f.TurnObObject();

        foods.Remove(f);

        OnListFoodChanged?.Invoke(this, EventArgs.Empty);
    }
}
