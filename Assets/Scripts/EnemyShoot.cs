using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootOffset = 1f;
    public float shootInterval = 2f; // Agregamos un intervalo entre disparos

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRepeatedly());
    }

    IEnumerator ShootRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootOffset);
            shootSpiral();
            yield return new WaitForSeconds(shootInterval); // Espera el intervalo antes de iniciar el próximo disparo
        }
    }

    void shootSpiral()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Destroy(bullet, 3f);
    }
}
