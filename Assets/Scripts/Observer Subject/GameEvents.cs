using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    // PUZZLE 1:
    public event Action<Transform> onPuzzle1StandEnter;
    public void GrabGravityGun(Transform player)
    {
        if (onPuzzle1StandEnter != null){
            onPuzzle1StandEnter(player);
        }
    }
}

