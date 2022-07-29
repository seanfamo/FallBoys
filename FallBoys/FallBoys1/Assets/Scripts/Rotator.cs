using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f / 0.01f, Space.Self);
    }
    
}
