﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static void EndGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}