using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField]private float minSpawnTime;
    [SerializeField]private float maxSpawnTime;
    private float timeUntilSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timeUntilSpawn -= Time.deltaTime;
       if(timeUntilSpawn <= 0){
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        setTimeUntilSpawn();
       } 
    }
    private void setTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
