using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyHandler : MonoBehaviour
{
    private int lifetime;

    void Start()
    {
        lifetime = 0;
    }

    void Move(int maxLifetime)
    {
        if (++lifetime == maxLifetime)
            Destroy(this.gameObject);
    }
}
