using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public int speed,jump_hight;
    int turn;

    bool flip;

    Rigidbody2D jump;
    // Start is called before the first frame update
    void Start () {
        jump = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey (KeyCode.D)) {
            transform.Translate (Vector2.right * speed * Time.deltaTime);
            turn = 1;
        }
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate (Vector2.left * speed * Time.deltaTime);
            turn = -1;
        }
        if (Input.GetKey (KeyCode.W)) {
            jump.AddForce(new Vector2(0, jump_hight));
        }
        if(turn > 0 && !flip){
            BodyFlip();
        }
        if(turn < 0 && flip){
            BodyFlip();
        }
    }

    void BodyFlip(){
        flip = !flip;
        Vector3 body = transform.localScale;
        body.x *= -1;
        transform.localScale = body;
    }
}