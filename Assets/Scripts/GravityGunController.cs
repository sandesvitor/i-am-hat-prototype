﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGunController : MonoBehaviour
{
    [SerializeField] private float _fireRate = 1f;
    private float _canFire = -1f;
    [SerializeField] private GameObject _gravityLaserPrefab;
    [SerializeField] private float _yRotationalSpeed = 45f;
    private Vector3 newEulerAngles;

    void Start()
    {
        GameEvents.current.onPuzzle1StandEnter += GimmeToPlayer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time > _canFire)
        {
            FireGravityLaser();
        }

        RotateY();
    }

    private void GimmeToPlayer(Transform player)
    {
        this.transform.parent = player;
        this.transform.localPosition = new Vector3(0.67f, 0f, 0.52f);
        this.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
    }

    private void RotateY()
    {
        float vertical = Input.GetAxis("Vertical");
        float velocity = vertical * Time.deltaTime * _yRotationalSpeed;
        newEulerAngles += new Vector3(0f, 0f, velocity);

        if(newEulerAngles.z <= 35f && newEulerAngles.z >= -35f)
        {
            transform.Rotate(0f, 0f, velocity);
        } 
        else if (newEulerAngles.z > 35f)
        {
            newEulerAngles = new Vector3(0f, 0f, 35f);
        }
        else if (newEulerAngles.z < -35f)
        {
            newEulerAngles = new Vector3(0f, 0f, -35f);
        }
    }

    void FireGravityLaser()
    {
        _canFire = Time.time + _fireRate;
        GameObject laser = Instantiate(
            _gravityLaserPrefab,
            this.transform.position,
            Quaternion.Euler(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z + -90f)
        );

        StartCoroutine(DestroyLaser(laser));
    }    
    
    private IEnumerator DestroyLaser(GameObject laser)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(laser);
    }

    private void OnDestroy()
    {
        GameEvents.current.onPuzzle1StandEnter -= GimmeToPlayer;
    }
}
