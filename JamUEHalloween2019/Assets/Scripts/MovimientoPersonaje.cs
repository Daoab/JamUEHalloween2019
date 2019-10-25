using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-speed, 0f, 0f) * Time.deltaTime; //Movimiento a la izquierda
            transform.forward = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed, 0f, 0f) * Time.deltaTime; //Movimiento a la derecha
            transform.forward = Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0f, 0f, speed) * Time.deltaTime; //Movimiento hacia delante
            transform.forward = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0f, 0f, -speed) * Time.deltaTime; //Movimiento hacia atras
            transform.forward = Vector3.back;

        }
    }
}
