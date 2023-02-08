using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour{
    public float speed = 250.0f;
    public float jumpForce = 12.0f;

    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
     AudioSource _jumpsound;
    
    // Start is called before the first frame update
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        _jumpsound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(min.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = false; //changes to true if the player is on the ground and majes them 
        //able to jump.
        if (!Mathf.Approximately(deltaX, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1); //when moving scale postive or negative 1 to face left or right.
        }                                                                  //detects if the player is on the ground or in the air.
            if (hit != null) {
            grounded = true;
        }
        //Creates an jump impulse when the space key is pressed. 
        _body.gravityScale = grounded && deltaX == 0 ? 0 : 1;
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpsound.Play();
        }
        //checks if the platform is moving or not.
        MovingPlatforms platform = null;
        if (hit != null) {
            platform = hit.GetComponent<MovingPlatforms>(); 
        }
        //either attach the player to platform or clear transform.parent.
        if (platform != null) {
            transform.parent = platform.transform;
        } else {
            transform.parent = null;
        }
        _anim.SetFloat("speed", Mathf.Abs(deltaX)); //speed greater than zero.
        Vector3 pScale = Vector3.one;
        if (platform != null) {
            pScale = platform.transform.localScale;
        }
        if (deltaX != 0) {
            transform.localScale = new Vector3(
                Mathf.Sign(deltaX) / pScale.x, 1 / pScale.y, 1);
        }
    }
}
