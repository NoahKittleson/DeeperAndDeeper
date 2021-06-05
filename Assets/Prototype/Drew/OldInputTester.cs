using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputTester : MonoBehaviour
{
    public void HandleInput(Vector2 direction, float power)
    {
        Debug.Log($"Direction {direction} --- power {power}");
    }
}
