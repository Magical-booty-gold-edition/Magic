using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour{
    public float speed = 500.0f;

    private Rigidbody2D _body;
    private Animator _anim;
    
    // Start is called before the first frame update
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0)){
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}
