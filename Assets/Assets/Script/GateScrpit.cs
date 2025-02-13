using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScrpit : MonoBehaviour
{
    [SerializeField] private GameObject Door_Close;
    [SerializeField] private GameObject Door_Open;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Door_Close.SetActive(false);
            Door_Open.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Door_Close.SetActive(true);
            Door_Open.SetActive(false);
        }
    }


}
