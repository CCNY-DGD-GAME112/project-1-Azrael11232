using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platformPrefab;

    public int minY = 0;
    public int maxY = 8;
    public float spawnDelay = 10f;
    public float scale = 1f;

    public Transform player;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPlatform), 1f, spawnDelay);
    }

   
    

    void SpawnPlatform()
    {
        float randomY = Random.Range(minY, maxY);
        float newY = player.position.y + randomY;
        float newX = player.position.x + 20f;

        Vector3 spawnPos = new Vector3(newX, newY, 0f);

        Instantiate(platformPrefab, spawnPos, Quaternion.identity);


        float offsetY = Random.Range(-10f, 10f);
        float offsetx = Random.Range(5f, 20f);

        Instantiate(platformPrefab, spawnPos + new Vector3(offsetx,  offsetY , 0f), Quaternion.identity);
    }
}




