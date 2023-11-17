using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodDeliveryVisual : MonoBehaviour
{
    public static FoodDeliveryVisual Instance { get; private set; }

    [SerializeField] private List<Transform> slots;
    private List<Food> foods;


    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        FoodDelivery.instance.OnListFoodChanged += Instance_OnListFoodChanged;
        UpdateVisual();
    }

    private void Instance_OnListFoodChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        foods = FoodDelivery.instance.GetListFoodDeliver();
        for (int i = 0; i < slots.Count; i++) 
        {
            if(i >= foods.Count)
            {
                if (slots[i].childCount > 0)
                {
                    DestroyChildOfSlot(i);
                }
            }
            else
            {
                if (slots[i].childCount > 0)
                {
                    DestroyChildOfSlot(i);
                }
                Transform foodTransform = Instantiate(foods[i].GetFoodSO().perfap, slots[i]);
                foodTransform.localScale = new Vector3 (.05f, 1f, 1f);
            }
        }
    }

    public void DestroyChildOfSlot(int indexSlot)
    {
        foreach(Transform child in slots[indexSlot])
        {
            Destroy(child.gameObject);
        }
    }
    public Transform getPostionInList(int index)
    {
        return slots[index];
    }
}
