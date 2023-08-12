using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{

    // Attribute (thuoojc tinhs)
    [SerializeField] private int speed =10; // Biến private nhưng vẫn hiển thị ở Inspector
                                        // 
    [Header("Player Name")]
    public string playerName;

    [Range(0,10)]
    public int speedLimit;

    [Tooltip("Tool tip")]
    public int toolTip;

    [ContextMenu("Context Menu")]
    private void MyContextMenu()
    {
        Debug.Log("My Context Menu Clicked!");
    }

    [HideInInspector]
    public int time;

    private void Update()
    {
        // Debug.Log(Time.deltaTime);// thời gian trôi qua tính từ lần cập nhật trước đến lúc hiện tại
        Time.timeScale = 0;  // => Thường được sử dụng để pause game
        Time.timeScale = 1; // Trở về trạng thái bình thường 
    }
}
