using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGameManager : MonoBehaviour
{
    public static FoodGameManager instance;
    public event EventHandler OnGameOver;
    public event EventHandler<OnPauseGameParam> OnGamePaused;
    public event EventHandler OnWinGame;
    public class OnPauseGameParam : EventArgs
    {
        public bool isPaused;
    }
    [SerializeField] private List<GameObject> listFoodPerfap;
    private List<Food> listStart;

    private float timeToEnd = 20f;
    private bool isPaused = false;

    private void Awake()
    {
        instance = this;
        listStart = new List<Food>();
    }
    public void Start()
    {
        FoodDelivery.instance.OnListFoodChanged += Instance_OnListFoodChanged;
        SpawnFood();
    }

    private void Instance_OnListFoodChanged(object sender, EventArgs e)
    {
        if (FoodDelivery.instance.GetListFoodDeliver().Count >= FoodDelivery.instance.GetMaxItem())
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Update()
    {
      if(timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
            if (timeToEnd <= 0)
            {
                Debug.Log("End Game");
                timeToEnd = 0;
                OnGameOver?.Invoke(this, EventArgs.Empty);
            }
        }
      if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            PausedGame();
        }
    }
    public void SpawnFood()
    {
        foreach (GameObject foodGameObject in listFoodPerfap)
        {
            SpawnFoodTimes(6, foodGameObject);
        }
    }
    public float GetTime()
    {
        return timeToEnd;
    }
    public void SpawnFoodTimes(int times,GameObject foodGameObject)
    {
        for(int i =0; i < times; i++) 
        {
           GameObject food =  Instantiate(foodGameObject, new Vector3(UnityEngine.Random.Range(-7, 7), .5f, UnityEngine.Random.Range(-11, -7)), Quaternion.identity);
           Food f = food.GetComponent<Food>();
            listStart.Add(f);
        }
    }

    public void PausedGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, new OnPauseGameParam
            {
                isPaused = isPaused
            });
        }
        else
        {
            Time.timeScale = 1f;
            OnGamePaused?.Invoke(this, new OnPauseGameParam
            {
                isPaused = isPaused
            });
        }
    }
    public void RemoveAFoodInStartList(Food food)
    {
        listStart.Remove(food);
        if (CheckWinGame())
        {
            OnWinGame?.Invoke(this, EventArgs.Empty);
        }
        
    }
    public void AddAFoodToListStart(Food food)
    {
        listStart.Add(food);
    }
    public bool CheckWinGame()
    {
        return listStart.Count == 0;
    }
}
