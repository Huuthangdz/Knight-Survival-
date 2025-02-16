using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EnemiManager : MonoBehaviour
{
    [SerializeField] private PlayerManager Player;
    [SerializeField] private float Speed;
    [SerializeField] private float Distance_Reality;
    private float Distance;
    private float Max_Health = 100f;
    [SerializeField] private KnockBackScript KnockBack;
    private float KnockBack_Force = 5f;
    private AudioManagerScript AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
            Distance = Vector2.Distance(Player.transform.position, transform.position);
            Vector2 Direction = Player.transform.position - transform.position;

            Direction.Normalize();

            float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 180f;

            if (Distance < Distance_Reality)
            {
                Vector3 newPosition = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
                newPosition.z = transform.position.z;

                transform.position = newPosition;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackArea"))
        {
            Max_Health -= 40f;
            Debug.Log(Max_Health);
            if (Max_Health <= 0)
            {
                AudioManager.AudioPlaySFX(AudioManager.Enemy_Die_Sound);
                Destroy(gameObject);
            }
            AudioManager.AudioPlaySFX(AudioManager.Hit_Sound);
            KnockBack.KnockBack(Player.transform, KnockBack_Force);
        }
    }
}
