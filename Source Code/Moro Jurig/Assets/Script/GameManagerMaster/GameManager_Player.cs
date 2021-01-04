using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager_Player : MonoBehaviour
{
    public FirstPersonController playerController;
    private GameManager_Master gameManagerMaster;

    void OnEnable() 
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePlayerController;
    }

    void OnDisable() 
    {
        gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
    }

    void SetInitialReferences() 
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TogglePlayerController() 
    {
        if(playerController != null)
        {
            playerController.enabled = !playerController.enabled;
        }
    }
}
