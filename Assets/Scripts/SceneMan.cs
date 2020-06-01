using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuCanvas.activeInHierarchy)
        {
            menuCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuCanvas.activeInHierarchy)
        {
            if (optionsMenu.activeInHierarchy)
            {
                optionsMenu.SetActive(false);
            }
            else
            {
                menuCanvas.SetActive(false);
            }
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

    public void screenToggle(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
