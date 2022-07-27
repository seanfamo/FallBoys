using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] Transform _target; //kameraya karakterimi hedef gösteriyorum
    [SerializeField] Vector3 _offset; // mesafe
    [SerializeField] float _chasingSpeed = 5; //takip etme hýzý

    private void Start()
    {
        if (!_target)
        {
            _target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }   //targeti böyle buluyorum
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _chasingSpeed * Time.deltaTime); 
        //position'dan target'a kovalama hýzý kadar kameram takip etsin
    }
}
