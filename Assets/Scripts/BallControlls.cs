using UnityEngine;
using UnityEngine.InputSystem;

public class BallControlls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float Strength = 5.0f;
    public InputAction moveAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
        var x = moveAction.ReadValue<Vector2>();

        Debug.Log(x);
        // GetComponent<Rigidbody>().AddForce()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
