using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossObject;
    public float waitTime = 1f;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ1 = -10f;
    public float maxZ1 = 10f;
    public float minZ2 = -10f;
    public float maxZ2 = 10f;
    public int maxEnemies = 100;
    private int counter = 0;
    private bool canGenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    public void CreateEnemy()
    {
        if (counter >= maxEnemies)
        {
            canGenerate = false;
            RemoveEnemies();
            ActivateBoss();
            return;
        }
        float randomZ;
        if (Random.Range(0, 2) == 0)
        {
            // Use the first set of z values
            randomZ = Random.Range(minZ1, maxZ1);
        }
        else
        {
            // Use the second set of z values
            randomZ = Random.Range(minZ2, maxZ2);
        }

        Vector3 newPosition = new Vector3(Random.Range(minX, maxX), 2f, randomZ);
        GameObject newEnemy = Instantiate(enemyPrefab, newPosition, Quaternion.identity);

        counter++;

        Enemy createEnemy = newEnemy.GetComponent<Enemy>();
        if (createEnemy != null)
        {
            createEnemy.generator = this;
        }
    }

    IEnumerator GenerateEnemies()
    {
        while (canGenerate)
        {
            yield return new WaitUntil(() => GameObject.FindWithTag("Enemy") == null);
            CreateEnemy();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void RemoveEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    void ActivateBoss()
    {
        bossObject.SetActive(true);
    }
}
