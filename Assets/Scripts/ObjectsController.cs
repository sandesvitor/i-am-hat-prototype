using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Rigidbody _rb;

    [Header("Physics Properties")]
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _mass = 1f;
    [SerializeField] private float _density = 1f;
    [SerializeField] private float _staticFriction = .6f;
    [SerializeField] private Vector3 _initForce = Vector3.zero;

    [Header("Event Condition")]
    [SerializeField] private bool _haveGravityGun = false;

    [SerializeField] private bool _onTriggerArea = false;

    private void Start()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.useGravity = true;
        _rb.mass = _mass;
        //_rb.drag = 0.5f;
        _rb.SetDensity(_density);
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _rb.AddForce(_initForce * _gravity);
        _rb.isKinematic = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onTriggerArea)
        {
            Debug.Log("Spaces Pressed on " + this.gameObject.name);
            Hold();
        }

        if (Input.GetKeyUp(KeyCode.Space) && _onTriggerArea)
        {
            Debug.Log("Spaces Released on " + this.gameObject.name);
            LetGo();
        }
    }

    private void Levitate()
    {
        _rb.AddForce(this.transform.up * 400, ForceMode.Acceleration);
        _rb.useGravity = false;
    }

    private void Hold()
    {
        _rb.isKinematic = true;
        this.transform.parent = _player;
    }

    private void LetGo()
    {
        _rb.isKinematic = false;
        this.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "Laser")
        {
            Levitate();
            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            _onTriggerArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _onTriggerArea = false;
        }
    }
}