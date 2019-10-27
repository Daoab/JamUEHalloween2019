using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    MovimientoPersonaje player;
    Camera camera;

    void Start()
    {
        player = FindObjectOfType<MovimientoPersonaje>();
        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (player.transform.position.x >= 0f) ShowLeftSide();
        else ShowRightSide(); 
    }

    void ShowRightSide()
    {
        offsetX = 1.14f;
        offsetY = 2.78f;
        this.gameObject.transform.forward = (transform.position - camera.transform.position).normalized;
        this.transform.position = player.transform.position + new Vector3(offsetX, offsetY, 0f);
    }

    void ShowLeftSide()
    {
        offsetX = -1.32f;
        offsetY = 3.12f;
        this.gameObject.transform.forward = (camera.transform.position - transform.position).normalized;
        this.transform.position = player.transform.position + new Vector3(offsetX, offsetY, 0f);
    }
}
