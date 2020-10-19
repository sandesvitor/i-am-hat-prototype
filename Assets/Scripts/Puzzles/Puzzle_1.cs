using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.current.GrabGravityGun(other.transform);
        }
    }
}
