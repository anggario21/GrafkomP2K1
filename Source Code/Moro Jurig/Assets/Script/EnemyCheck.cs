using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCheck : MonoBehaviour
{

    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Sisa :" + enemies.Length);
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene(3); // Load the scene with name "OtherSceneName"
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
