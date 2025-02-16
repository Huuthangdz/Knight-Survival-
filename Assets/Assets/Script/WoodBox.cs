using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    private AudioManagerScript AudioManager;

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();

    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackArea"))
        {
            Destroy(gameObject);
            AudioManager.AudioPlaySFX(AudioManager.Wood_Box_Sound);
        }
    }
}
