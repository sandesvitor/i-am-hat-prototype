using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _turretHead;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _firePosition;

    [Header("Variables")]
    [SerializeField] private float _turn_speed = 45f;
    [SerializeField] private float range = 15f;


    private LineRenderer _lineRenderer;
    private bool _playerInSight = false;

    private void Start()
    {
        // currently on the Laser_Barrel Game Object
        _lineRenderer = this.GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        if (_playerInSight)
        {
            Vector3 playerPos = _player.position;
            RotateTowards(playerPos);
            Laser(playerPos);
        } else
        {
            if (_lineRenderer.enabled)
            {
                _lineRenderer.enabled = false;
            }
        }
    }

    protected void RotateTowards(Vector3 to)
    {

        Quaternion _lookRotation =
            Quaternion.LookRotation((to - _turretHead.position).normalized);

        //over time
        _turretHead.rotation =
            Quaternion.Slerp(_turretHead.rotation, _lookRotation, Time.deltaTime * _turn_speed);

        //instant
        _turretHead.rotation = _lookRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInSight = false;
        }
    }

    private void Laser(Vector3 position)
    {
        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
        }

        RaycastHit hit;
        if (Physics.Raycast(
            _firePosition.transform.TransformPoint(Vector3.zero),
            _firePosition.transform.TransformDirection(Vector3.up), 
            out hit))
        {
            if (hit.collider)
            {
                Debug.Log(hit.transform.gameObject.name);
                
                _lineRenderer.SetPosition(0, _firePosition.position);
                _lineRenderer.SetPosition(1, hit.point);

                if (hit.collider.gameObject == _player.gameObject)
                {
                    GameManager.GameOver();
                }

                //Debug.DrawRay(
                //    _firePosition.transform.TransformPoint(Vector3.zero),
                //    _firePosition.transform.TransformDirection(Vector3.up),
                //    Color.green);
            }
        }
    }
}

