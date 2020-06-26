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

    private bool isFullscreen = true;
    
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
                    Time.timeScale = 1;
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
                    Time.timeScale = 1;
                }
            }
            else
            {
                menuCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }

        MenuNavigation();

        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (isFullscreen)
            {
                Screen.SetResolution(1600, 900, false);
                isFullscreen = false;
                Debug.Log("Not Fullscreen");
            }
            else
            {
                Screen.SetResolution(1920, 1080, true);
                isFullscreen = true;
                Debug.Log("Fullscreen");
            }
        }
    }

    void MenuNavigation()
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
