using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lesson03 : MonoBehaviour
{
    // Tính khoảng cách từ A - B trong không gian 3D
    public Transform pointA;
    public Transform pointB;

    private void Update()
    {
        // Tính khoảng cách giữa PointA và PointA
        float distance = (pointA.position - pointB.position).magnitude;

        Debug.Log("Khoảng cách giữa hai điểm A và B: " + distance);
    }
}
