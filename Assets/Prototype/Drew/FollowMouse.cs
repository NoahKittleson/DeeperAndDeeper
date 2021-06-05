using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        var targetPosition = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = this.transform.position.z;
        this.transform.position = targetPosition;
    }
}
