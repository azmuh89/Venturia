using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScreenManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject statsMenu, skillsMenu, settingsMenu, mainMenuView, quitView, equipmentMenu;
    public GameObject statsButton, skillsButton, settingsButton, mainMenuButton, quitButton, equipmentButton;
    public Toggle fullScreen;
    public Dropdown resolutionDropdown;

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
            if (settingsMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject != settingsButton)
                {
                    EventSystem.current.SetSelectedGameObject(settingsButton);
                }
                else
                {
                    menuCanvas.SetActive(false);
                }
            }
            else if (equipmentMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject != equipmentButton)
                {
                    EventSystem.current.SetSelectedGameObject(equipmentButton);
                }
                else
                {
                    menuCanvas.SetActive(false);
                }
            }
            else
            {
                menuCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }

        menuNavigation();
    }

    void menuNavigation()
    {
        if (EventSystem.current.currentSelectedGameObject == statsButton)
        {
            SelectedButton(statsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == skillsButton)
        {
            SelectedButton(skillsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == settingsButton)
        {
            SelectedButton(settingsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == mainMenuButton)
        {
            SelectedButton(mainMenuView);
        }
        else if (EventSystem.current.currentSelectedGameObject == quitButton)
        {
            SelectedButton(quitView);
        }
        else if (EventSystem.current.currentSelectedGameObject == equipmentButton)
        {
            SelectedButton(equipmentMenu);
        }
    }

    void SelectedButton(GameObject activeObject)
    {
        statsMenu.SetActive(false);
        skillsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenuView.SetActive(false);
        quitView.SetActive(false);
        equipmentMenu.SetActive(false);

        activeObject.gameObject.SetActive(true);
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

    public void DestroyDontDestroy()
    {
        Destroy(GameObject.Find("Player"));
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
