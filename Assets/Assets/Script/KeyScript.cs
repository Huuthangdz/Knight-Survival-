using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    public bool pickedUp ;
    private Vector2 vel;
    private AudioManagerScript AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position, ref vel, 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !pickedUp)
        {
            pickedUp = true;
            AudioManager.AudioPlaySFX(AudioManager.Touch_Key_Sound);
        }
    }
}
