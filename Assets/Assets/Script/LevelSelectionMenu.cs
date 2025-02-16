using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    [SerializeField] private Button[] Buttons;
    [SerializeField] private GameObject Level_Button;

    private float currentLevel;
    private AudioManagerScript AudioManager;

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
        ButtonToArray();
        int unLockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        for (int i = 0; i < Buttons.Length; i++)
        {            
            Buttons[i].interactable = false;
        }
        for ( int i = 0; i < unLockedLevels; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    public void OnClickLevel(int Level_Num)
    {
        SceneManager.LoadScene("Level"+ Level_Num);
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);
    }

    private void ButtonToArray()
    {
        int childCount = Level_Button.transform.childCount;
        Buttons = new Button[childCount];

        for ( int i = 0; i < childCount; i++)
        {
            Buttons[i] = Level_Button.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    public void BackToCurrentLevel()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene("Level" + currentLevel);
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);

    }
}
