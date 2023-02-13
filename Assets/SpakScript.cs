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

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakPå.GetComponent<SpriteRenderer>().sprite;

        isPå = true; 
    }
}