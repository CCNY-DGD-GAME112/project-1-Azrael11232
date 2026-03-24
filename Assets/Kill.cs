using UnityEngine;

public class Kill : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player object
            Destroy(collision.gameObject);
        }
    }
}
