using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Starting Game Main Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }


    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Testing box");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Press me"))
        {
            Debug.Log("Press me button got pressed");
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Press me 2"))
        {
            QuitGame();
        }

    }

}
