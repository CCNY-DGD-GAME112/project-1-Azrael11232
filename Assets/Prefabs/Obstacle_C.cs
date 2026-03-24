    using UnityEngine;

public class Obstacle : MonoBehaviour
{  public GameObject ObstaclePrefab;


    public float spawnDelay = 1.1f;
    public int minY = 5;
    public int maxY = 12;
    

    public Transform player;

    void Start()
        {
        InvokeRepeating(nameof(SpawnObstacleC), 1f, spawnDelay);
        }

   void SpawnObstacleC()
    {
        float newX = player.position.x + 15f;
        
        Vector3 spawnPos = new Vector3(newX, 0f, 0f);
        GameObject obstacle = Instantiate(ObstaclePrefab, spawnPos, Quaternion.identity);
    
        float randomY = Random.Range(minY, maxY);
        obstacle.transform.localScale = new Vector3(1f, randomY, 1f);
    }
}




