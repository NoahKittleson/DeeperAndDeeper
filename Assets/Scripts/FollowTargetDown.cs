using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetDown : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float delay = 1f;

    void Update()
    {
        var diff = target.position - this.transform.position;
        diff.z = 0;
        diff.x = 0;
        if (diff.y > 0) diff.y = 0;
        var translation = diff / delay * Time.deltaTime;
        this.transform.Translate(translation);
    }
}
