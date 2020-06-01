using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    private GameObject menuCanvas;

    void Awake()
    {
        menuCanvas = GameObject.FindGameObjectWithTag("Menu");
    }

    void Start()
    {
        menuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuCanvas.activeInHierarchy)
        {
            menuCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuCanvas.activeInHierarchy)
        {
            menuCanvas.SetActive(false);
        }
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
