using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Physics Properties")]
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _mass = 1f;
    [SerializeField] private float _density = 1f;
    [SerializeField] private float _staticFriction = .6f;
    [SerializeField] private Vector3 _initForce = Vector3.zero;

    [Header("Event Condition")]
    [SerializeField] private bool _haveGravityGun = false;

    private void Start()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.useGravity = true;
        _rb.mass = _mass;
        //_rb.drag = 0.5f;
        _rb.SetDensity(_density);
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _rb.AddForce(_initForce * _gravity);
    }

    private void Levitate()
    {
        _rb.AddForce(this.transform.up * 400, ForceMode.Acceleration);
        _rb.useGravity = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Levitate();
            Destroy(other.gameObject);
        }
    }




    // FAZER DEPOIS >>>
    //private void ReactivateGravity()
    //{
    //    _rb.useGravity = true;
    //}
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
}