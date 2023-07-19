using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void DOMOI()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Zanovo()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
