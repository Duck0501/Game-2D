using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 1.5f, spawnRadius = 4f;
    private float spawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnEnemy();
            spawnTimer = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);    
    }
    private void spawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

}
