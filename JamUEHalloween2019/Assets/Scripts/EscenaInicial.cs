using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
   public void cambioSpriteJugar()
    {
        //transform.localScale = new Vector3(1.2f, 1.2f);
     
    }
    public void botonFuera()
    {
        //transform.localScale = new Vector3(1f, 1f);
    }

}
