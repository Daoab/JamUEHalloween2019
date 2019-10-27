using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static void EndGame(bool finishedWriting)
    {
        if(finishedWriting) SceneManager.LoadScene(4, LoadSceneMode.Single);
        else SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}