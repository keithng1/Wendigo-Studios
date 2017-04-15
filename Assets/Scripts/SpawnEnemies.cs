using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject[] waypoints;



    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;
	private float waittime = 5.0f;

    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public float spawnInterval = 2;
        public int maxEnemies = 20;
    }

 

    // Use this for initialization
    void Start () {
        lastSpawnTime = Time.time;
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
	
	// Update is called once per frame
	void Update () {


		if (Time.time < waittime) {
			return;
		}



        // 1
        int currentWave = gameManager.Wave;
       // print(currentWave + " " + waves.Length);
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                HealthBar hb = newEnemy.transform.FindChild("HealthBar").GetComponent<HealthBar>();
                hb.waveScale(currentWave, gameManager.waveScaler);

                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.finish();
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
        else
        {
			gameManager.victory = true;
        }



    }
}
