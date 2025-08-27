using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int Score = 0;

    public float IncDisplacement = 5f;

    float Displaced = 0;
    Vector3 LastPos = Vector3.zero;

    public AudioSource source;
    public AudioClip ScoreInc;
    void FixedUpdate()
    {
        Displaced += (transform.position - LastPos).magnitude;
        LastPos = transform.position;
        if (Displaced > IncDisplacement)
        {
            source.pitch = 1;
            source.PlayOneShot(ScoreInc);
            Score += 1;
            Displaced -= IncDisplacement;
        }
    }

    void Awake()
    {
        LastPos = transform.position;
        Score = 0;
    }
}
