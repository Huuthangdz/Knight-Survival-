using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private GameObject Chest;
    [SerializeField] private GameObject Open_Chest;

    private AudioManagerScript AudioManager;

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackArea"))
        {
            AudioManager.AudioPlaySFX(AudioManager.Chest_Open_Sound);
            Debug.Log("hello");
            Destroy(Chest);
            Open_Chest.SetActive(true);
        }
    }
}
