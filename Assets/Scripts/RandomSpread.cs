using UnityEngine;

public class RandomSpread : MonoBehaviour
{
    public Vector3 spread;

    void Awake()
    {
        transform.position = transform.position + new Vector3(
            spread.x * (Random.value - 0.5f),
            spread.y * (Random.value - 0.5f),
            spread.z * (Random.value - 0.5f)
        );
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spread * 2f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
