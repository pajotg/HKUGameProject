using UnityEngine;
using UnityEngine.InputSystem;

public class BallControlls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float SideStrength = 5.0f;
    public float ForwardStrength = 5.0f;
    InputAction moveAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        var move = moveAction.ReadValue<Vector2>();

        GetComponent<Rigidbody>().AddForce(new Vector3(move.y * ForwardStrength, 0, -move.x * SideStrength));
    }
}
