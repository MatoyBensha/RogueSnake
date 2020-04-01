using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHandler : MonoBehaviour
{
    public bool shouldRespawn;

    public int min_x;
    public int max_x;

    public int min_y;
    public int max_y;

    private float offset = .5f;

    public Transform transform;
    public SpriteRenderer spriteRenderer;

    // Incase it lands on something
    private int framesBeforeShowing = 15;
    private int framesCounter = 0;

    void Start()
    {
        spriteRenderer.enabled = false;

        min_x += (int)transform.position.x;
        max_x += (int)transform.position.x;

        min_y += (int)transform.position.y;
        max_y += (int)transform.position.y;

        NewLocation();
    }

    void Update()
    {
        if (spriteRenderer.enabled == false)
            if (++framesCounter == framesBeforeShowing)
                spriteRenderer.enabled = true;
    }

    public void NewLocation()
    {
        int x = Random.Range(min_x, max_x);
        int y = Random.Range(min_y, max_y);

        transform.position = new Vector3(x + offset, y + offset, 0);
        Debug.Log("Apple moved to " + transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        framesCounter = 0;

        if (shouldRespawn || spriteRenderer.enabled == false)
            NewLocation();
        else
            Destroy(this.gameObject);
    }
}
