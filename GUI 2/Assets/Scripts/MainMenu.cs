using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
// Public Class is the name of your Script 
// Monobehaviour is the base class for every unity script made
{
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    #region Public variables
    //Allows you to close and open text under name
    public string LoadScene = "GameScene";
    //Represents text as a series of characters
    //string is allias for system string
    public Dropdown qualityDropdown;
    //Shows the different quality options in options menu
    public Toggle fullscreenToggle;
    //Allows you to toggle between fullscreen and not fullscreen
    public GameObject IWantToDisableThis;
    //Disables game object that it's attached to
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen) //This changes the screen from fullscreen to windowed
    {
        Screen.fullScreen = isFullScreen;
    }

    public Resolution[] resolutions;
    public Dropdown resolution;

    #endregion
    public void Start()
    //Public Void is Name for group of code 
    {
        Debug.Log("Starting Game Main Menu");
        //Sends a command to unity 
        if (!PlayerPrefs.HasKey("fullscreen"))
        //Saves player preferences between game sessions
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }
        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("quality", 5);//dont have magic numbers
            QualitySettings.SetQualityLevel(5);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }
        PlayerPrefs.Save();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    #region Change settings

    private void Start2()//This is for setting resolution
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[1].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && 
               resolutions[1].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    #endregion
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #region Save and load player prefs
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        //PlayerPrefs.SetInt("qualityDropdown.value);
        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
        PlayerPrefs.Save();
    }
    public void LoadPlayerPrefs()
    {
        qualityDropdown.value = PlayerPrefs.GetInt("quality");
        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }
    #endregion
}





