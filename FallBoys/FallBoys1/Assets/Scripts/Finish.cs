using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject _wall;
    public PlayerMovement playerMovement;
    public Animator _animator;
    private void Start()
    {
        _animator.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("isMoving", false);
            
            _wall.SetActive(true);

            playerMovement.enabled = false;
        }
    }
}
