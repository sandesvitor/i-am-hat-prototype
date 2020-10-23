using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _hat;
    [SerializeField] private GameObject _gravityGun;
    [SerializeField] private float _speed = 5f;
    private Rigidbody _rb;
   

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();

        if (_rb == null)
        {
            Debug.LogError("RigidBody component is not attached to " + gameObject.name);
        }

        _rb.useGravity = true;

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        _rb.AddForce(move * _speed);
    }

    void Update()
    {
    }
}
