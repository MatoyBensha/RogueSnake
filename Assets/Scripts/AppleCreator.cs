using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreator : MonoBehaviour
{

    public GameObject applePrefab;
    public int gapX;
    public int gapY;
    public int amountX;
    public int amountY;

    void Start()
    {
        for (int x = -gapX * (amountX / 2); x < gapX * (amountX / 2); x += gapX)
        {
            for (int y = -gapY * (amountY / 2); y < gapY * (amountY / 2); y += gapY)
            {
                Instantiate(applePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
}
