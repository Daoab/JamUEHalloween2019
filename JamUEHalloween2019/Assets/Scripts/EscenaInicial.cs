using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaInicial : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public bool juego;
    public bool controles;
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
    void onMouseUp()
    {
        if (juego)
        {
            SceneManager.loadScene();
        }
        if (controles)
        {
            SceneManager.loadScene();
        }
    }
}
