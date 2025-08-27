using UnityEngine;

public class RandomDestroy : MonoBehaviour
{
    public AnimationCurve DestroyChance;

    void Awake()
    {
        if (Random.value < DestroyChance.Evaluate(ScoreCounter.Score))
        {
            Destroy(gameObject);
        }
    }
}
