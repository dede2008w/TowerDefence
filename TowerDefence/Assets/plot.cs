using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;

    private GameObject tower;

    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }


    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }


    private void OnMouseExit()
    {
        sr.color = startColor; 
    }


    private void OnMouseDown()
    {
        
    }
}
