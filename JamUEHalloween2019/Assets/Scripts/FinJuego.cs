using System.Collections;
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
    public void cambiaJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void enterBoton()
    {
        transform.localScale = new Vector3(1.2f, 1.2f);
    }
    public void salirBoton()
    {
        transform.localScale = new Vector3(1f, 1f);
    }
}
