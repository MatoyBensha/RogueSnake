using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{

    public SpriteRenderer mapText;

    private static bool isPaused;
    private static bool firstPause;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        firstPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Only works at the start of the game
        if (Input.GetKey(KeyCode.Space))
        {
            firstPause = false;
            isPaused = false;

            mapText.enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown("m") && !firstPause)
            isPaused = !isPaused;
    }

    public static bool IsPaused()
    {
        return isPaused;
    }

    public static bool IsFirstPaused()
    {
        return firstPause;
    }
}
