using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScreenManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject statsMenu, inventoryMenu, equipmentMenu, skillsMenu, saveLoadMenu, settingsMenu, exitMenu;
    public GameObject statsButton, inventoryButton, equipmentButton, skillsButton, saveLoadButton, settingsButton, exitButton;
    public GameObject invItemsButton, invWeaponsButton, invArmorsButton, invQuestItemsButton;
    public GameObject invItemsMenu, invWeaponsMenu, invArmorsMenu, invQuestItemsMenu;

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
            if (invItemsMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject == inventoryButton)
                {
                    menuCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
                else if (EventSystem.current.currentSelectedGameObject != invItemsButton)
                {
                    EventSystem.current.SetSelectedGameObject(invItemsButton);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(inventoryButton);
                }
            }
            else if (invWeaponsMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject == inventoryButton)
                {
                    menuCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
                else if (EventSystem.current.currentSelectedGameObject != invWeaponsButton)
                {
                    EventSystem.current.SetSelectedGameObject(invWeaponsButton);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(inventoryButton);
                }
            }
            else if (invArmorsMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject == inventoryButton)
                {
                    menuCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
                else if (EventSystem.current.currentSelectedGameObject != invArmorsButton)
                {
                    EventSystem.current.SetSelectedGameObject(invArmorsButton);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(inventoryButton);
                }
            }
            else if (invQuestItemsMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject == inventoryButton)
                {
                    menuCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
                else if (EventSystem.current.currentSelectedGameObject != invQuestItemsButton)
                {
                    EventSystem.current.SetSelectedGameObject(invQuestItemsButton);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(inventoryButton);
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
            else if (settingsMenu.activeInHierarchy)
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
            else if (exitMenu.activeInHierarchy)
            {
                if (EventSystem.current.currentSelectedGameObject != exitButton)
                {
                    EventSystem.current.SetSelectedGameObject(exitButton);
                }
                else
                {
                    menuCanvas.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }

        MenuNavigation();

        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (isFullscreen)
            {
                Screen.SetResolution(1600, 900, false);
                isFullscreen = false;
            }
            else
            {
                Screen.SetResolution(1920, 1080, true);
                isFullscreen = true;
            }
        }
    }

    void MenuNavigation()
    {
        if (EventSystem.current.currentSelectedGameObject == statsButton)
        {
            SelectMenu(statsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == inventoryButton)
        {
            SelectMenu(inventoryMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == invItemsButton)
        {
            SelectInventory(invItemsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == invWeaponsButton)
        {
            SelectInventory(invWeaponsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == invArmorsButton)
        {
            SelectInventory(invArmorsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == invQuestItemsButton)
        {
            SelectInventory(invQuestItemsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == equipmentButton)
        {
            SelectMenu(equipmentMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == skillsButton)
        {
            SelectMenu(skillsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == saveLoadButton)
        {
            SelectMenu(saveLoadMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == settingsButton)
        {
            SelectMenu(settingsMenu);
        }
        else if (EventSystem.current.currentSelectedGameObject == exitButton)
        {
            SelectMenu(exitMenu);
        }
    }

    void SelectMenu(GameObject activeMenu)
    {
        statsMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        equipmentMenu.SetActive(false);
        skillsMenu.SetActive(false);
        saveLoadMenu.SetActive(false);
        settingsMenu.SetActive(false);
        exitMenu.SetActive(false);

        activeMenu.SetActive(true);
    }

    void SelectInventory(GameObject invMenu)
    {
        invItemsMenu.SetActive(false);
        invWeaponsMenu.SetActive(false);
        invArmorsMenu.SetActive(false);
        invQuestItemsMenu.SetActive(false);

        invMenu.SetActive(true);
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
