using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Menu : MonoBehaviour
{
    private GameManager_Master gameManagerMaster;
    public GameObject menu;
    
    void Start()
    {
       
    }

    void Update()
    {
        CheckForMenuToggleRequest();
    }

    void OnEnable()
    {
        SetInitialReference();
        gameManagerMaster.GameOverEvent += ToggleMenu;
    }

    void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
    }

    void SetInitialReference()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void CheckForMenuToggleRequest()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallEventMenuToggle();
        }
        else
        {
            Debug.LogWarning("You need to assign a UI GameObject to the Toggle Menu script in the inspector");
        }
    }
}
