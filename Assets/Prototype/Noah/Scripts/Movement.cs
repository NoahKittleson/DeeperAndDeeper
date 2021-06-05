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
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("I did it!");
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10,-10);
        }
    }
}
