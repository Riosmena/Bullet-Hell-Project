using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalBoss : MonoBehaviour
{
    public int health = 500;
    public float speed = 5f;
    public float radius = 50f;
    public Transform player;
    public TMP_Text GGText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Mira hacia la dirección del jugador
        transform.forward = direction;

        // Mueve al jefe hacia el jugador
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GGText.gameObject.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0f;
    }

}
