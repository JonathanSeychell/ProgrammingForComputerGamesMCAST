using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // a method which loads the Scene: SceneName
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit(string msg)
    {
        if (msg == "quit")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
