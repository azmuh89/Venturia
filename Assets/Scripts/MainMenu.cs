using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Toggle fullScreen;
    public Dropdown resolutionDropdown;
    public Button playButton;
    public Button settingsButton;

    void Awake()
    {
        fullScreen.isOn = intToBool(PlayerPrefs.GetInt("FullScreen"));
        
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        playButton.OnSelect(new BaseEventData(EventSystem.current));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeInHierarchy)
            {
                settingsPanel.SetActive(false);
                EventSystem.current.SetSelectedGameObject(settingsButton.gameObject);
            }
        }
    }

    public void LoadScene(string sceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
        SceneFade.instance.Fade();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FullScreenToggle(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        PlayerPrefs.SetInt("FullScreen", boolToInt(isFullScreen));
    }

    public void ScreenResolution()
    {
        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, fullScreen.isOn);
        }
        else if (resolutionDropdown.value == 1)
        {
            Screen.SetResolution(1600, 900, fullScreen.isOn);
        }
        else if (resolutionDropdown.value == 2)
        {
            Screen.SetResolution(1440, 900, fullScreen.isOn);
        }
        else if (resolutionDropdown.value == 3)
        {
            Screen.SetResolution(1366, 768, fullScreen.isOn);
        }
        else if (resolutionDropdown.value == 4)
        {
            Screen.SetResolution(1280, 720, fullScreen.isOn);
        }
        else if (resolutionDropdown.value == 5)
        {
            Screen.SetResolution(1024, 768, fullScreen.isOn);
        }
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
