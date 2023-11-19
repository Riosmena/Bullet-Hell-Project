using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int counterA = 0;
    public float life = 3f;

    void Start()
    {
        counterA++;
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            FinalBoss boss = collision.gameObject.GetComponent<FinalBoss>();
            boss.TakeDamage(1);
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        counterA--;
    }
}
