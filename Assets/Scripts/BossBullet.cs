using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 10f;
    public static int bulletC = 0;

    void Start()
    {
        Destroy(gameObject, 3f);
        bulletC++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("Player1"))
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
        bulletC--;
    }
}
