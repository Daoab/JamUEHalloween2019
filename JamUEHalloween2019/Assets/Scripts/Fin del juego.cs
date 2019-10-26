using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Findeljuego : MonoBehaviour
{

    public bool juego;
    public bool inicio;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseUp()
    {
        if (juego)
        {
            SceneManager.LoadScene(1);
        }
        if (inicio)
        {
            SceneManager.LoadScene(0);
        }
    }
}
