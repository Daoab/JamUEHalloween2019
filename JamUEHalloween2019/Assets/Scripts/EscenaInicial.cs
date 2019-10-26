using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaInicial : MonoBehaviour
{
    void Start()
    {
    }

    public void cambiaTutorial()
    {
        SceneManager.LoadScene(2);
    }
    public void cambiaJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void salirJuego()
    {
        Application.Quit();
    }
    

}
