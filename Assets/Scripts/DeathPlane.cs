using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public TileSpawner spawner;
    public Transform player;

    void Update()
    {
        var p = transform.InverseTransformPoint(spawner.next + Vector3.down * 5);
        if (p.y < 0)
        {
            transform.position = spawner.next;
        }

        if (transform.InverseTransformPoint(player.position).y < 0)
        {
           FindFirstObjectByType<BallControlls>().OnDeath();
        }
    }
}
