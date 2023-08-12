using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = topLeftTarget;
    }

    // Update is called once per frame
    void Update()
    {
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
