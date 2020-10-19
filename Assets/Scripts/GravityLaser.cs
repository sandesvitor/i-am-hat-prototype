using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLaser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Update()
    {
        this.transform.Translate(new Vector3(0f, 1f, 0f) * _speed * Time.deltaTime);
    }
}
