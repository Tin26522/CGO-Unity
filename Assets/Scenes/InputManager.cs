using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void Start()
    {
        float angle = 45f;

        float radians = angle * Mathf.Deg2Rad;

        Debug.Log(radians);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("chuot trai");

        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("chuot phai");

        }
        if (Input.GetMouseButton(2))
        {
            Debug.Log("chuot giua");

        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("<color=red> Mau do </color>");
        }
    }
}
