using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BallControlls : MonoBehaviour
{
    public float maxSpeed = 100;
    public float SpeedReductionStrenght = 0.5f;

    public float SideVel = 5.0f;
    public float SideVelStrength = 0.8f;
    public float ForwardStrength = 5.0f;
    InputAction moveAction;

    public float AirTimeExpSpeed = 0.2f;

    public float AirTime = 0;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        var move = moveAction.ReadValue<Vector2>();

        var rb = GetComponent<Rigidbody>();

        var vel = rb.linearVelocity;

        if (vel.z > maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, -(vel.z - maxSpeed) * SpeedReductionStrenght), ForceMode.Acceleration);
        }

        rb.AddForce(new Vector3((move.x * SideVel - vel.x) * SideVelStrength * Time.fixedDeltaTime, 0, 0), ForceMode.VelocityChange);
        rb.AddForce(new Vector3(0, -AirTime * AirTimeExpSpeed, move.y * ForwardStrength), ForceMode.Acceleration);

        AirTime += Time.fixedDeltaTime;
    }

    void OnCollisionStay(Collision collision)
    {
        AirTime = 0;
    }
}
