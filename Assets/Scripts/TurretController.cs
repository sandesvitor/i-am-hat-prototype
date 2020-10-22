using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _turretHead;
    [SerializeField] private Transform _player;
    private bool _playerInSight = false;
    [SerializeField] private float _turn_speed = 45f;

    void Update()
    {
        if (_playerInSight)
        {
            Vector3 playerPos = _player.position;
            rotateTowards(playerPos);
        }
    }

    protected void rotateTowards(Vector3 to)
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
            Debug.Log("Hello Player!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInSight = false;
            Debug.Log("Bye Player...");
        }
    }
}
