using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject ball;

    public Vector3 Offset;

    void Update()
    {
        transform.position = ball.position + offset;
    }
}
