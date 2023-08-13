using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public enum TargetEnum
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    }

    public float speed;

    public Transform topLeftTarget;
    public Transform topRightTarget;
    public Transform bottomLeftTarget;
    public Transform bottomRightTarget;

    private Transform currentTarget;
    private TargetEnum nextTarget = TargetEnum.TopLeft; // Gán trạng thái đầu tiên là TopLeft


    public enum DriveMode { Manual, Automatic }
    public DriveMode mode = DriveMode.Manual;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = topLeftTarget;
    }


    private void Update()
    {
        if (mode == DriveMode.Automatic)
        {
            // Xử lý tự động lái xe
            AutoDrive();
        }
        else if (mode == DriveMode.Manual)
        {
            // Xử lý lái xe thủ công
              ManualDrive();
        }
    }

    private void AutoDrive()
    {
        // Xử lý lái xe tự động

        Vector3 targetPosition = currentTarget.position;
        Vector3 moveDirection = targetPosition - transform.position;

        float distance = moveDirection.magnitude;

        if (distance > 0.1f)
        {
            // Khi chưa tới thì vẫn di chuyển về điểm focus
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        }
        else
        {
            // Chuyển target
            SetNextTarget(nextTarget);
        }

        // Thay đổi góc quay theo hướng target object
        Vector3 direction = currentTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;
    }

    private void ManualDrive()
    {
        // Sử dụng Input.GetAxis để lấy giá trị trục điều khiển từ bàn phím
        float horizontalMove = Input.GetAxis("Horizontal"); // Giá trị từ -1 (sang trái) đến 1 (sang phải)
        float verticalMove = Input.GetAxis("Vertical"); // Giá trị từ -1 (lùi lại) đến 1 (tiến tới)

        // Tính toán vector dịch chuyển dựa trên input
        Vector3 movement = new Vector3(horizontalMove, 0f, verticalMove) * speed * Time.deltaTime;

        // Áp dụng dịch chuyển vào vị trí của xe
        transform.Translate(movement);
    }

  

    private void SetNextTarget(TargetEnum target)
    {
        switch (target)
        {
            case TargetEnum.TopLeft:
                currentTarget = topLeftTarget;
                nextTarget = TargetEnum.TopRight;
                break;
            case TargetEnum.TopRight:
                currentTarget = topRightTarget;
                nextTarget = TargetEnum.BottomLeft;
                break;
            case TargetEnum.BottomLeft:
                currentTarget = bottomLeftTarget;
                nextTarget = TargetEnum.BottomRight;
                break;
            case TargetEnum.BottomRight:
                currentTarget = bottomRightTarget;
                nextTarget = TargetEnum.TopLeft;
                break;
        }
    }
}
