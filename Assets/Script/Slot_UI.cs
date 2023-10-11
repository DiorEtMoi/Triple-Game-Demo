using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_UI : MonoBehaviour
{
    public MeshFilter filter;
    public void Awake()
    {
        filter = GetComponent<MeshFilter>();
    }
    public void setUI(Game.FoodType foodType)
    {
       switch (foodType)
        {
            case Game.FoodType.None:
                filter.mesh = null; break;
            case Game.FoodType.Purple:
                filter.mesh = Game.instance.dict[foodType].perfaps.GetComponent<MeshFilter>().sharedMesh; break;
            case Game.FoodType.IceCream:
                filter.mesh = Game.instance.dict[foodType].perfaps.GetComponent<MeshFilter>().sharedMesh; break;
            case Game.FoodType.Leaf:
                filter.mesh = Game.instance.dict[foodType].perfaps.GetComponent<MeshFilter>().sharedMesh; break;
            case Game.FoodType.Slipper:
                filter.mesh = Game.instance.dict[foodType].perfaps.GetComponent<MeshFilter>().sharedMesh; break;
        }
    }
  
   
}
