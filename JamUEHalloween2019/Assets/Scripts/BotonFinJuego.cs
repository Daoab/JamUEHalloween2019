using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonFinJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void irACreditos()
    {
        SceneManager.LoadScene(3);
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
