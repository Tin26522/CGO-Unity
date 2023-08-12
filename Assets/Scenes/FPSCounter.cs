using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    private void Update()
    {
        float fps = 1/Time.deltaTime;
        Debug.Log(fps);
    }

    private void FixedUpdate()
    {
        // Xử lý vật lý
    }
}
