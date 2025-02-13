using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrikeScript : MonoBehaviour
{
    [SerializeField] private GameObject Strike1;
    [SerializeField] private GameObject Strike2;
    [SerializeField] private GameObject Strike3;
    
    private float strikeTime2 = 1f;
    private float strikeTime3 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Strike2AtiveCoroutine());
        StartCoroutine(Strike3AtiveCoroutine());
    }

    private IEnumerator Strike2AtiveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(strikeTime2);
            Strike2.SetActive(true);

            yield return new WaitForSeconds(2f);
            Strike2.SetActive(false);

            yield return new WaitForSeconds(strikeTime2);
        }
    }

    private IEnumerator Strike3AtiveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(strikeTime3);
            Strike3.SetActive(true);

            yield return new WaitForSeconds(2f);
            Strike3.SetActive(false);

            yield return new WaitForSeconds(strikeTime3);
        }
    }
}
