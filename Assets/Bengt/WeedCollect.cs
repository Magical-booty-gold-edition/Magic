using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Weed")) {
            Destroy(collider2D.gameObject);
        }
    }
}
