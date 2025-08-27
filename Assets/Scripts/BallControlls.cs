using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BallControlls : MonoBehaviour
{
    public AnimationCurve maxSpeed;

    public AudioSource source;
    public AudioClip landingClip;
    public AudioClip deathClip;
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

    public string DeathScene = "Main Menu";
    public ParticleSystem deathParticles;

    bool HasDied = false;
    public void OnDeath()
    {
        if (HasDied) { return; }
        HasDied = true;

        source.pitch = 1.0f;
        source.PlayOneShot(deathClip);
        GetComponent<Rigidbody>().isKinematic = true;
        deathParticles.Emit(1000);
        GetComponent<MeshRenderer>().enabled = false;
        Invoke(nameof(LoadDeathScene), 1f);
    }

    void LoadDeathScene()
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
        if (HasDied) { return; }
        
        var move = moveAction.ReadValue<Vector2>();
        var rb = GetComponent<Rigidbody>();
        var vel = rb.linearVelocity;

        var velDotDiff = Vector3.Dot(LastVel.normalized, vel.normalized);
        if (velDotDiff < 0.95)
        {
            source.pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Clamp01(GetComponent<Rigidbody>().linearVelocity.magnitude / maxPitchSpeed));
            source.PlayOneShot(landingClip);
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
