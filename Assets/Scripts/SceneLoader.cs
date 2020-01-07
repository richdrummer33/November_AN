using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Must match the name of the scene exactly (scene in assets folder)

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
