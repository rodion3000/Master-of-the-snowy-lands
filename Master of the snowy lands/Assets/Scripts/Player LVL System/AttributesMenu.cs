using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesMenu : MonoBehaviour
{
    public GameObject MenuAttributes;

    public static bool GameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        MenuAttributes.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        MenuAttributes.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
