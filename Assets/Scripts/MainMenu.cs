using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play Button clicked");
        SceneManager.LoadScene("Level 1");
    }

    public void OpenStats()
    {
        Debug.Log("Stats clicked");
        SceneManager.LoadScene("StatsScreen"); 
    }

    public void GoBacktoMenu()
    {
        Debug.Log("Home clicked");
        SceneManager.LoadScene("Home");
    }
}
