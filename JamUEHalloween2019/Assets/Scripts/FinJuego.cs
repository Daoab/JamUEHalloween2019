﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void volverAInicio()
    {
        SceneManager.LoadScene(0);
    }

    public void salirJuego()
    {
        Application.Quit();
    }
}
