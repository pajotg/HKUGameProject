using UnityEngine;

public class Despawn : MonoBehaviour
{
    Transform player;

    void Awake()
    {
        player = FindFirstObjectByType<BallControlls>().transform;
    }

    void Update()
    {
        if (transform.position.z + 250 < player.position.z)
        {
            Destroy(gameObject);
        }
    }
}
