﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Findeljuego : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public bool juego;
    public bool inicio;
    // Start is called before the first frame update
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()
    {
        if (juego)
        {
            //SceneManager.LoadScene();
        }
        if (inicio)
        {
            //SceneManager.LoadScene();
        }
    }
}
