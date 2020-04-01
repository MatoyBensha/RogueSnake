using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(0);
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
