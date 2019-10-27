﻿using System.Collections;
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
        this.gameObject.transform.forward = (transform.position - camera.transform.position).normalized;
        this.transform.position = player.transform.position + new Vector3(offsetX, offsetY, 0f);
    }
}