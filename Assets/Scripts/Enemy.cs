using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador;  // Referencia al transform del jugador
    public float velocidad = 5f;  // Velocidad de movimiento del enemigo
    public float radius = 50f;  // Radio de detección del enemigo
    public CreateEnemies generator;

    void Start()
    {
        generator = GameObject.FindObjectOfType<CreateEnemies>();
    }
    void Update()
    {
        if (jugador != null)
        {
            float distance = Vector3.Distance(transform.position, jugador.position);
            if (distance <= radius)
            {
                // Calcula la dirección hacia el jugador
                Vector3 direccion = jugador.position - transform.position;
                direccion.Normalize();  // Normaliza para mantener una velocidad constante

                // Mira hacia la dirección del jugador
                transform.forward = direccion;

                // Mueve al enemigo hacia el jugador
                transform.position += direccion * velocidad * Time.deltaTime;
            }
        }
    }

    void OnDestroy()
    {
        if (generator != null)
        {
            generator.CreateEnemy();
        }
    }
}
