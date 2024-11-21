using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI cureencyUI;

    private void OnUGI()
    {
    currencyUI.text = LevelManager.main.currency.ToString();
    
    }

    public void SetSelected()
    { 
    
    }
}
