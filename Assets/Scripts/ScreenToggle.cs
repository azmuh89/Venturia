using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    public void toggleScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
