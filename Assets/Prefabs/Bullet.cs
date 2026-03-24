using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public Transform player;
    public float speed = 8f;
    public float spawnDelay = 2f;
    public float offset = 30f;
    public Timer timer;

    private bool spawningStarted = false; // <-- new flag

    void Update()
    {
        if (timer.finished && !spawningStarted)
        {
            spawningStarted = true;   
            SpawnObstacle(); 
            InvokeRepeating(nameof(SpawnObstacle), 0f, spawnDelay);
            timer.finished = false;       
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(player.position.x + offset, player.position.y, 0f);
        GameObject obstacle = Instantiate(ObstaclePrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = new Vector2(-speed, 0f);
    }

    // Optional: call this when you want to allow spawning again
    public void ResetSpawning()
    {
        spawningStarted = false;
    }
}