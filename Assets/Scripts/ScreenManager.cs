using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsMenu;
    public GameObject equipmentMenu;
    public Toggle fullScreen;

    void Awake()
    {
        fullScreen.isOn = intToBool(PlayerPrefs.GetInt("FullScreen"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuCanvas.activeInHierarchy)
        {
            menuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuCanvas.activeInHierarchy)
        {
            if (optionsMenu.activeInHierarchy)
            {
                optionsMenu.SetActive(false);
            }
            else if (equipmentMenu.activeInHierarchy)
            {
                equipmentMenu.SetActive(false);
            }
            // add else if for other menus
            else
            {
                menuCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void LoadScene(string sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ScreenToggle(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (!isFullScreen)
        {
            Screen.SetResolution(1280, 720, false);
            PlayerPrefs.SetInt("FullScreen", boolToInt(false));
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
            PlayerPrefs.SetInt("FullScreen", boolToInt(true));
        }

        PlayerPrefs.Save();
    }
    
    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
