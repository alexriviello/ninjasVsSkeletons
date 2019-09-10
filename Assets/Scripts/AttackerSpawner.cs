using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(attackerPrefab, transform.position, transform.rotation); // spawn attacker at position**
    }

    void Update()
    {
        
    }

}
