using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator playerAnim;
    public TMP_Text healthText;
    public TMP_Text gameOverText;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    public void TakeDamage()
    {
        currentHealth--;
        currentHealth = Mathf.Max(0, currentHealth);
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
            }

            // Detenemos la animación de movimiento del jugador
            PlayerController player = GetComponent<PlayerController>();
            player.enabled = false;

            playerAnim.ResetTrigger("idle");
            playerAnim.SetTrigger("Die");

            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5f);
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
