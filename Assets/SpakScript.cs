using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpakScript : MonoBehaviour
{
    [SerializeField]
    GameObject SpakAv;

    [SerializeField]
    GameObject SpakPå;

    public bool isPå = false;
    bool atLever = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    void FixedUpdate()
    {
        if (Input.KeyDown)(KeyCode.E) && atLever);  
        { 
            gameObject.GetCompnent<SpriteRenderer>().sprite = SpakPå.Getcompnent<SpriteRenderer>().sprite; 
        }
    }

    void onTriggerExit2D()
    {
        atLever = false;
    }
    
}