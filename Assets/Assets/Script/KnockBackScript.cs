using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnockBackScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Knock_Back_Time = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void KnockBack(Transform PlayerTransform, float force)
    {
        StartCoroutine(KnockBackCoroutine(PlayerTransform, force));
    }

    private IEnumerator KnockBackCoroutine(Transform PlayerTransform,float force)
    {
        float elapsed = 0f;
        Vector2 direction = (transform.position - PlayerTransform.position).normalized;

        while (elapsed < Knock_Back_Time)
        {
            rb.velocity = direction * force;
            elapsed += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.velocity = Vector2.zero;
    }
}
