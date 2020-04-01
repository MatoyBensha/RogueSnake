using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera camera;

    // Could get this from camera.size * resolution but im lazy (this is 16:10)
    private int x_size = 8; 
    private int y_size = 5; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera != null)
        {
            Vector3 pos = camera.transform.position;
            Vector3 dir = (this.transform.position - camera.transform.position);

            Debug.Log(dir);

            if (dir.x > x_size)
                camera.transform.position += new Vector3(x_size * 2, 0, 0);
            else if (dir.x < -x_size)
                camera.transform.position += new Vector3(-x_size * 2, 0, 0);
            else if (dir.y > y_size)
                camera.transform.position += new Vector3(0, y_size * 2, 0);
            else if (dir.y < -y_size)
                camera.transform.position += new Vector3(0, -y_size * 2, 0);
        }
    }
}
