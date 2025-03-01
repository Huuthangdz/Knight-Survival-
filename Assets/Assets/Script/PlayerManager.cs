using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player_rb;
    [SerializeField] private float speed;
    [SerializeField] private Animator player_animator;
    [SerializeField] private GameObject Attack_Area;
    [SerializeField] private JoystickAttack Joy_Stick_Attack;
    [SerializeField] private JoystickAttack Joy_Stick_Move;
    [SerializeField] private GameObject Lose_Panel;

    private PauseUIScript PauseUIScript;
    private float Attack_Distance = 0.8f;
    private bool facing_Right;
    private Vector2 move_input;
    private Vector2 Attack_Direction;
    private bool Can_Attack = true;
    private AudioManagerScript AudioManager;

    void Start()
    {
        PauseUIScript = GameObject.FindGameObjectWithTag("PauseButton").GetComponent<PauseUIScript>();
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        PauseUIScript.MuteButtonClick();
        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex);
        if (Joy_Stick_Move.Joy_stick_Vec.y != 0 || Joy_Stick_Move.Joy_stick_Vec.x != 0)
        {
            move_input = Joy_Stick_Move.Joy_stick_Vec;
        }
        else
        {
            move_input = Vector2.zero;
        }
        player_rb.velocity = move_input * speed;
        ManageFlip();

        if(Joy_Stick_Attack.Joy_stick_Vec.y != 0 || Joy_Stick_Attack.Joy_stick_Vec.x != 0)
        {
            Attack_Direction = Joy_Stick_Attack.Joy_stick_Vec;

            if(Can_Attack)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            player_animator.SetBool("Attack", false);
        }
    }

    public void setMoveInput(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
    }
    private void ManageFlip()
    {
        if ( player_rb.velocity.x > 0 && facing_Right)
        {
            flip();
        }
        else if (player_rb.velocity.x < 0 && !facing_Right)
        {
            flip();
        }
    }
    private void flip()
    {
        facing_Right = !facing_Right;
        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator Attack()
    {
        Can_Attack = false;
        player_animator.SetBool("Attack", true);
        Vector2 Attack_pos = (Vector2)transform.position + Attack_Direction * Attack_Distance;
        Vector3 Attack_pos_3D = new Vector3(Attack_pos.x, Attack_pos.y, Attack_Area.transform.position.z);

        float angle = Mathf.Atan2(Attack_Direction.y, Attack_Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        
        GameObject Fire = Instantiate(Attack_Area, Attack_pos_3D,rotation);
        AudioManager.AudioPlaySFX(AudioManager.Attack_Sound);
        StartCoroutine(EndAttack(Fire));

        yield return new WaitForSeconds(0.5f);
        Can_Attack = true;
    }
    private IEnumerator EndAttack(GameObject Fire)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(Fire);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemi"))
        {
            Lose_Panel.SetActive(true);
            Time.timeScale = 0;
            AudioManager.AudioPlaySFX(AudioManager.Die_Sound);
        }
        if (collision.gameObject.CompareTag("StrikeArea"))
        {
            Lose_Panel.SetActive(true);
            Time.timeScale = 0;
            AudioManager.AudioPlaySFX(AudioManager.Die_Sound);

        }
    }
    public void MenuClickOn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UIScene");
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);
    }
    public void RestartClickOn()
    {
        Time.timeScale = 1;
        AudioManager.AudioPlaySFX(AudioManager.On_Click_Sound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}