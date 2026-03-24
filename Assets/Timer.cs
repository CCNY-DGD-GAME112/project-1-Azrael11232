using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool finished = false;
    public float timer = 5f; // starting time
    public TextMeshProUGUI timerText;

    private float startingTime;

    void Awake()
    {
        if (timer <= 0f)
            timer = 5f; // default fallback
        startingTime = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = startingTime; // automatically reset
            finished = true;
        }
        else
        {
            finished = false;
        }

        timerText.text = $"Bullet spawns in: {timer:F2}s";
    }
}