using Unity.VisualScripting;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = PlayerManager.Instance.transform.position;
        
        if (transform.position.x < playerPosition.x - 50f)
        {
            Destroy(gameObject);
        }
    }
}
