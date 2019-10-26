using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaInicial : MonoBehaviour
{
    public bool juego;
    public bool controles;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseUp ()
    {
        if (juego)
        {
            Debug.Log("Joder");
            SceneManager.LoadScene(1);
        }
        if (controles)
        {
            Debug.Log("JJoder");
            SceneManager.LoadScene(2);
        }
    }
}
