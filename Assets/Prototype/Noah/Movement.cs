using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)) {
        //     Debug.Log("I did it!");
        //     Move(new Vector2(-10, -10), 1);
        // }
    }

    public void Move(Vector2 mousePosition, float power) {
        Vector2 playerPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction =  mousePosition - playerPosition;
        GetComponent<Rigidbody2D>().velocity = direction * 5 * power;
    }
}
