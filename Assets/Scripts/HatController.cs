using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    [SerializeField] private float _hatYOffset = -0.10f;
    
    void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        this.transform.position = this.transform.parent.position
            + new Vector3(0, this.transform.parent.localScale.y + _hatYOffset, 0);

        this.transform.rotation = this.transform.parent.rotation;
    }
}
