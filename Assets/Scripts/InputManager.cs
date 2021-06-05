using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MouseUpEvent : UnityEvent<Vector2, float> { }

public class InputManager : MonoBehaviour
{
    public MouseUpEvent onMouseUp;

    private float mouseDownTime;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var timeDelta = Time.time - this.mouseDownTime;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.onMouseUp.Invoke(mouseWorldPosition, timeDelta);
        };

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownTime = Time.time;
        }
    }
}
