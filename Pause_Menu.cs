using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuUi;
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume ()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    
    public void Quit()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }    
}
