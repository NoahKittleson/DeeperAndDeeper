using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetDown : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float delay = 1f;

    [SerializeField]
    private float lagDistance = 0f;

    void Update()
    {
        var yDiff = target.position.y + lagDistance - this.transform.position.y;
        if (yDiff > 0) yDiff = 0;
        var yTranslation = yDiff / delay * Time.deltaTime;
        var translation = new Vector3(0, yTranslation, 0);
        this.transform.Translate(translation);
    }
}
