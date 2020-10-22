using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCounter : MonoBehaviour
{
    public float enemyDeaths;
    public float killGoal;
    public bool spawnBoss;
    public Transform bossSpawnPoint;
    public Transform bossDropPod;
    public bool spawnOnce;
    public bool bossKilled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDeaths >= killGoal)
        {
            spawnBoss = true;
        }
        if(spawnBoss == true & !spawnOnce)
        {
            BossSpawn();
        }
    }
    void BossSpawn()
    {
        Instantiate(bossDropPod, bossSpawnPoint.position, bossSpawnPoint.rotation);
        spawnOnce = true;
    }
}
