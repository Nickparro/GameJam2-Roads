using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool gamePaused = false;
    public AudioClip ambientSound;
    [SerializeField] private GameObject pausePanel, gameOverPanel;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SoundManager.Instance.PlayMusic(ambientSound);
        ResumeGame();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogManager.instance.dialogState)
        {
            if (gamePaused)
            {
                ResumeGame();
                pausePanel.SetActive(false);
            }
            else
            {
                PauseGame();
                pausePanel.SetActive(true);

            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        PauseGame();
        gameOverPanel.SetActive(true);
    }
}
