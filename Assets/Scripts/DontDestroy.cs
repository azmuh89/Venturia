using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;
    private Scene scene;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
