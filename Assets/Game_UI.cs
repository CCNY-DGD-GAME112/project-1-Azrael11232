using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager Instance;
    public GameObject pauseScreen;
    public GameObject deathScreen;

    private bool gamePaused = false;
    private bool playerDead = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ResumeGameUI();
    }

    void Update()
    {
        // Toggle pause anytime
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TogglePause();

        // Reset game
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ResetGame();
    }

    void TogglePause()
    {
        gamePaused = !gamePaused;
        if (gamePaused) Pause();
        else ResumeGameUI();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        if (pauseScreen != null) pauseScreen.SetActive(true);
    }

    public void ResumeGameUI()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        if (pauseScreen != null) pauseScreen.SetActive(false);
        if (deathScreen != null) deathScreen.SetActive(false);
    }

    public void PlayerDied()
    {
        if (playerDead) return;
        playerDead = true;
        Time.timeScale = 0f;
        if (deathScreen != null) deathScreen.SetActive(true);
    }

    public void ResetGame()
    {
        playerDead = false;
        gamePaused = false;
        Time.timeScale = 1f;

        // Reload scene to reset everything
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}