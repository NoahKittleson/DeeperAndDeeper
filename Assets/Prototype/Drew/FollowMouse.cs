using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowMouse : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var diff = mousePosition - transform.position;
        rb2d.AddForce(diff, ForceMode2D.Impulse);
    }
}
