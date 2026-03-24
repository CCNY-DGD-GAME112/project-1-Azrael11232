
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
   
    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPosition = player.position;
        transform.position = new Vector3(targetPosition.x + 5, targetPosition.y, -10);
    }
}
