using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Pause : MonoBehaviour
{
    private GameManager_Master gameManagerMaster;
    private bool isPaused;
    void OnEnable()
    {
        setInitialReference();
        gameManagerMaster.MenuToggleEvent += TogglePause;
    }

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePause;
    }

    void setInitialReference()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            //isPaused = false;
        }

        else
        {
            Time.timeScale = 1;
            //isPaused = true;    
        }
    }
}
