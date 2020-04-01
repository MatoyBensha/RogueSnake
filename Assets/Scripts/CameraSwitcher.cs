using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera mainCamera;
    public Camera mapCamera;
    
    private bool camSwitch = false;

    void Start()
    {
        ChangeCams();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
            ChangeCams();
    }

    void ChangeCams()
    {
        camSwitch = !camSwitch;
        mainCamera.gameObject.SetActive(camSwitch);
        mapCamera.gameObject.SetActive(!camSwitch);
    }
}
