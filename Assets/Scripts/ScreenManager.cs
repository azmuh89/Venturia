using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private static ScreenManager instance;
    private GameObject menuCanvas;
    private GameObject optionsMenu, statsMenu, equipmentMenu;
    private Toggle fullScreen;
    private Dropdown resolutionDropdown;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        menuCanvas = GameObject.Find("MenuCanvas");

        if (menuCanvas != null)
        {
            optionsMenu = menuCanvas.transform.Find("OptionsMenu").gameObject;
            statsMenu = menuCanvas.transform.Find("StatsMenu").gameObject;
            equipmentMenu = menuCanvas.transform.Find("EquipmentMenu").gameObject;

            fullScreen = optionsMenu.transform.Find("FullscreenToggle").GetComponent<Toggle>();
            resolutionDropdown = optionsMenu.transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
        }
    }

    void Start()
    {
        menuCanvas.SetActive(false);
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
            else if (statsMenu.activeInHierarchy)
            {
                statsMenu.SetActive(false);
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
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
        SceneFade.instance.Fade();
    }

    public void DestroyDontDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
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
