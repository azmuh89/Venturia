using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject buttonsPanel;
    public Button playButton;
    public Button settingsButton;

    void Awake()
    {
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
                buttonsPanel.SetActive(true);
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
}
