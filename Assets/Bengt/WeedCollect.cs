using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedCollect : MonoBehaviour {
    public AudioSource _coinpickup;

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("White")) {
            _coinpickup.Play();
            Destroy(collider2D.gameObject);
        }
    }
}
