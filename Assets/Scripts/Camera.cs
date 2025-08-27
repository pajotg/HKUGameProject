using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Ball;

    public Vector3 Offset;

    void Update()
    {
        transform.position = Ball.position + Offset;
    }
}
