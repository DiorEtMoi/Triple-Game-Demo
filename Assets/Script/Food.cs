using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodSO foodSO;
    private Vector3 startPostion;
    public enum FoodType
    {
        APPLE,
        BANANA,
        EGGPLANT,
        LEAF,
        FLIPFLOP,
        ICECREAM
    }
    private void Awake()
    {
        startPostion = transform.position;
    }
    public FoodSO GetFoodSO()
    {
        return foodSO;
    }
    public void OnMouseUpAsButton()
    {
        int indexToAddInList = FoodDelivery.instance.FindPositionToAdd(this);
        if(indexToAddInList == -1)
        {
            indexToAddInList = FoodDelivery.instance.GetListFoodDeliver().Count;
        }
        Debug.Log(indexToAddInList);
        transform.DOMove(FoodDeliveryVisual.Instance.getPostionInList(indexToAddInList).position
            ,.2f).OnComplete(() =>
            {
                // Add Food to Food Delivery
                FoodDelivery.instance.AddFoodToList(this);

                // Hide after add to list
                HideObject();
            });

       
    }
    public void HideObject()
    {
        gameObject.SetActive(false);
        FoodGameManager.instance.RemoveAFoodInStartList(this);
    }
    public void TurnObObject()
    {
        gameObject.SetActive(true);
        transform.DOMove(startPostion, 0.2f);
        FoodGameManager.instance.AddAFoodToListStart(this);
    }
}
