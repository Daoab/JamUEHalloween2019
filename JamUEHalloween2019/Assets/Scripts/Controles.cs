using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{

    public bool inicio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void volverAInicio() { 
            SceneManager.LoadScene(0);
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

