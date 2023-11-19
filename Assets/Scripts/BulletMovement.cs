using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public static int counterB = 0;
    public float life = 3f;
    public float speed = 10f;

    void Start()
    {
        counterB++;
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            TextUpdate textUpdate = other.gameObject.GetComponent<TextUpdate>();
            textUpdate.TakeDamage();
            textUpdate.Die();
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        counterB--;
    }
}
