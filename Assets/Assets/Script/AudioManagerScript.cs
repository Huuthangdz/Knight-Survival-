using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    [Header("-------------Audio Source--------------")]
    [SerializeField] public AudioSource Music_Source;
    [SerializeField] public AudioSource SFX_Source;

    [Header("-------------Audio Clip----------------")]
    [SerializeField] public AudioClip Back_Ground_Music;//
    [SerializeField] public AudioClip Attack_Sound;//
    [SerializeField] public AudioClip Hit_Sound;//
    [SerializeField] public AudioClip Die_Sound;//
    [SerializeField] public AudioClip Win_Sound;//
    [SerializeField] public AudioClip Chest_Open_Sound;
    [SerializeField] public AudioClip Enemy_Die_Sound;//
    [SerializeField] public AudioClip On_Click_Sound;
    [SerializeField] public AudioClip Touch_Key_Sound;//
    [SerializeField] public AudioClip Wood_Box_Sound;

    // Start is called before the first frame update
    void Start()
    {
        Music_Source.clip = Back_Ground_Music;
        Music_Source.Play();
    }

    public void AudioPlaySFX(AudioClip clip)
    {
        SFX_Source.PlayOneShot(clip);
    }

    public void MuteAudio()
    {
        PlayerPrefs.SetInt("Mute", 1);
        AudioListener.volume = 0;
    }

    public void UnMuteAudio()
    {
        PlayerPrefs.SetInt("Mute", 0);
        AudioListener.volume = 1;
    }
}
