using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRadius;
    public Transform spawnCenter;
    public GameObject skeletonPrefab;

    private float timeSinceLastSpawn = 0;
    private System.Random random;


    void Start(){
        random = new System.Random();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn > 3f){
            SpawnEnemy(RandomSpawnPoint());
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnEnemy(Vector3 enemyPos){
        GameObject enemies = GameObject.Find("Enemies");
        GameObject enemy = Instantiate(skeletonPrefab, enemies.transform);
        enemyPos.z = enemies.transform.position.z;
        enemy.transform.position = enemyPos;
        enemy.transform.rotation = Quaternion.identity;
    }

    private Vector3 RandomSpawnPoint(){
        Vector3 center = spawnCenter.position;
        float angle = (float)(random.NextDouble() * 361);
        Vector3 enemyPos = new Vector3(
            spawnRadius * (float)System.Math.Cos(angle) + center.x,
            spawnRadius * (float)System.Math.Sin(angle) + center.y,
            -2
            );
        return enemyPos;
        
    }
}
