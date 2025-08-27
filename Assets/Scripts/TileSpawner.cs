using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tiles;

    public Vector3 next;

    public float SpawnRange = 50;

    public void FixedUpdate()
    {
        if ((transform.position - next).sqrMagnitude > SpawnRange * SpawnRange) { return; }
        
        int index = Random.Range(0, tiles.Length);
        GameObject tile = Instantiate(tiles[index], next, tiles[index].transform.rotation);
        Transform endTransform = tile.transform.Find("end");
        if (endTransform != null)
        {
            next = endTransform.position;
        }
    }
}
