using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatfotm : MonoBehaviour
{
    public float rotationDirSpeed = 1;
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime * rotationDirSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(gameObject.transform, true);
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.transform.SetParent(gameObject.transform, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
        collision.transform.rotation = Quaternion.identity;
    }

}
