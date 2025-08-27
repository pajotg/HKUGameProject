using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        FindFirstObjectByType<BallControlls>().OnDeath();
    }
}
