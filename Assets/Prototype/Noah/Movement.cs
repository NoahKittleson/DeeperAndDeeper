using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 lastVelocity;
    public float scale = 5;
    public float maxTime = 1.5f;
    public bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     Debug.Log("I did it!");
        //     Move(new Vector2(-10, -10), 1);
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if we want to collide with the object
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Move(Vector2 mousePosition, float power) {
        if(alive) {
            power = Mathf.Min(power, maxTime);

            Vector2 playerPosition = GetComponent<Rigidbody2D>().position;
            Vector2 direction =  mousePosition - playerPosition;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * scale * power;
        }
    }

    public void Die(){
        alive = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
