using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int Score = 0;

    public float IncDisplacement = 5f;

    float Displaced = 0;
    Vector3 LastPos = Vector3.zero;
    void FixedUpdate()
    {
        Displaced += (transform.position - LastPos).magnitude;
        LastPos = transform.position;
        if (Displaced > IncDisplacement)
        {
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
