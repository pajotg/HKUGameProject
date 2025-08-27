using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public TileSpawner spawner;
    public Transform player;

    public string DeathScene;

    public void OnDeath()
    {
        SceneManager.LoadScene(DeathScene);
    }

    // Update is called once per frame
    void Update()
    {
        var p = transform.InverseTransformPoint(spawner.next);
        if (p.y < 0)
        {
            transform.position = spawner.next;
        }

        if (transform.InverseTransformPoint(player.position).y < 0)
        {
            OnDeath();
        }
    }
}
