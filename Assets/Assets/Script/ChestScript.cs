using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private GameObject Chest;
    [SerializeField] private GameObject Open_Chest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackArea"))
        {
            Debug.Log("hello");
            Destroy(Chest);
            Open_Chest.SetActive(true);
        }
    }
}
