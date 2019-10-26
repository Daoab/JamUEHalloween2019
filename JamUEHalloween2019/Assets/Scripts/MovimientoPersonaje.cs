using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    Animator anim;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.gameObject.SetActive(true);
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        stop();
        movement();
    }
    void stop()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walk", false);

        }
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-speed, 0f, 0f) * Time.deltaTime; //Movimiento a la izquierda
            transform.forward = Vector3.left;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed, 0f, 0f) * Time.deltaTime; //Movimiento a la derecha
            transform.forward = Vector3.right;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0f, 0f, speed) * Time.deltaTime; //Movimiento hacia delante
            transform.forward = Vector3.forward;
            anim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0f, 0f, -speed) * Time.deltaTime; //Movimiento hacia atras
            transform.forward = Vector3.back;
            anim.SetBool("walk", true);

        }
    }
}
