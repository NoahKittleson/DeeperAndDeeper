using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lava : MonoBehaviour
{

    public UnityEvent onPlayerDeath;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log($"collision! with: {other.gameObject.name}");
        if(other.gameObject.name == "Player") {
            this.onPlayerDeath.Invoke();
            Destroy(other.gameObject);
        }

        // if (other.GetType().GetMethod("Die") != null) {
        //     other.Die();
        // }
    }

}
