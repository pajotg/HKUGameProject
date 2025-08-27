using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BallControlls : MonoBehaviour
{
    public AnimationCurve maxSpeed;

    public AudioSource landingSource;
    public AudioClip landingClip;
    public float minPitch = 1.0f;
    public float maxPitch = 2.0f;
    public float maxPitchSpeed = 20.0f;
    
    public float SpeedReductionStrenght = 0.5f;

    public float SideVel = 5.0f;
    public float SideVelStrength = 0.8f;
    public float ForwardStrength = 5.0f;
    InputAction moveAction;

    public float AirTimeExpSpeed = 0.2f;

    public float AirTime = 0;

    public float LandVelDiff = 5;

    public string DeathScene = "Main Menu";

    public void OnDeath()
    {
        SceneManager.LoadScene(DeathScene);
    }

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    Vector3 LastVel;

    void FixedUpdate()
    {
        var move = moveAction.ReadValue<Vector2>();
        var rb = GetComponent<Rigidbody>();
        var vel = rb.linearVelocity;

        var velDotDiff = Vector3.Dot(LastVel.normalized, vel.normalized);
        if (velDotDiff < 0.95)
        {
            landingSource.pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Clamp01(GetComponent<Rigidbody>().linearVelocity.magnitude / maxPitchSpeed));
            landingSource.PlayOneShot(landingClip);
        }

        LastVel = vel;

        var maxSpeed = this.maxSpeed.Evaluate(ScoreCounter.Score);
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
