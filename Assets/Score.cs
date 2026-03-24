using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int Scores = 0;
    float BestX = 0;
    float BestY = 0;
    
    public GameObject player;
    public TextMeshProUGUI scoreText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
        if(player.transform.position.y>BestY)
        {
            BestY = player.transform.position.y;
        }

        
        if(player.transform.position.x>BestX)
        {
            BestX = player.transform.position.x;
        }
       
        
        Scores = ((int)(BestX/10 * BestY/10));
       
        scoreText.text = ("Score: " + Scores.ToString());
    }
}
