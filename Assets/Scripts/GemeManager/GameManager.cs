﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
