using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;


    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void increaseCurrency(int amount)
    {
    
    if (amount  <= currency)
        {
            currency -= amount;

        }

        
        else
        {
            Debug.Log("You do not have enough to purchase this item");
        }
        
    }

}
