using UnityEngine;

public class TeacherMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 5f;
    private Transform targetPoint;
    private bool isMoving = false;

    void Start()
    {
        targetPoint = transform.position.y < (pointA.position.y + pointB.position.y) / 2 ? pointB : pointA;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            targetPoint = pointB;
            isMoving = true;
        }
        else if (scroll < 0f)
        {
            targetPoint = pointA;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        }
    }
}
