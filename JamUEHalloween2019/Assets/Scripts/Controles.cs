using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{

    public bool juego;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()
    {
        if (juego)
        {
            SceneManager.LoadScene(1);
        }
    }
}
