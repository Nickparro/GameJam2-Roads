using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool gamePaused = false;
    public AudioClip ambientSound;
    [SerializeField] private GameObject pausePanel;
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
}
