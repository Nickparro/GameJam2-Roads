using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool gamePaused = false;
    public GameObject option;
    public AudioClip ambientSound;
    public AudioClip lateGameSound;
    [SerializeField] private GameObject pausePanel, gameOverPanel, winnerPanel;
    public GameObject rainParticles;
    public GameObject enemyGO;
    public bool playerWin = false;
    public GameObject lateTriggers;
    public GameObject earlyTriggers;
    public GameObject gasStationSignal;
    public LeanguageSetter leanguageSetter;


    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        PauseGame();
        StartCoroutine("IntroGame");
        leanguageSetter.UpdateText();
        
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (gamePaused)
            {
                ResumeGame();
                pausePanel.SetActive(false);
                option.SetActive(false);
            }
            else
            {
                PauseGame();
                pausePanel.SetActive(true);

            }
        }

        if(playerWin)
        {
            WinGame();
        }
    }

    public void LateGameStart()
    {
        rainParticles.SetActive(true);
        gasStationSignal.SetActive(false);
        SoundManager.Instance.PlayRain();
        SoundManager.Instance.PlayMusic(lateGameSound);
        lateTriggers.SetActive(true);
        earlyTriggers.SetActive(false);
    }

    public void ActivateEnemy()
    {
        enemyGO.SetActive(true);
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
    public void WinGame()
    {
        PauseGame();
        winnerPanel.SetActive(true);
    }

    IEnumerator IntroGame()
    {
        yield return new WaitForSecondsRealtime(35f);
        ResumeGame();
        SoundManager.Instance.PlayMusic(ambientSound);
        earlyTriggers.SetActive(true);
        
    }

}
