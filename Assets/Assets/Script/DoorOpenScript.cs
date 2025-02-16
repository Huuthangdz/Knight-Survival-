using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DoorOpenScript : MonoBehaviour
{
    [SerializeField] private GameObject Success_Panel;

    private AudioManagerScript AudioManager;

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SuccessUI();
            UnlockNewLevel();
            AudioManager.AudioPlaySFX(AudioManager.Win_Sound);
        }
    }
    private void SuccessUI()
    {
        Success_Panel.SetActive(true);
        Time.timeScale = 0;
    }
    private void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void MenuClickOn()
    {
        SceneManager.LoadScene("UIScene");
        Time.timeScale = 1;
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);

    }

    public void NextLevelClickOn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);

    }
}
