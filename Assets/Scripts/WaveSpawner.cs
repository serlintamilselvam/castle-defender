using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{


    public static int enemiesAlive;
    public Wave[] waves;
    //public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f; 
    private int waveIndex = 0;

    public Text waveCountdownText;
    public GameObject GameWonUI;

    void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if(enemiesAlive > 0 )
        {
            return;
        }
        if(countdown <= 0f)
        {
            if (PlayerStats.Lives <= 0)
            {
                return;
            } else
            {
                StartCoroutine(SpawnWave());
            }
                
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text =string.Format("{0:00.00}", countdown);


    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for(int i=0; i< wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;
        if(PlayerStats.Lives > 0)
        {
            if (waveIndex == waves.Length)
            {
                Debug.Log("Level Won!");
                this.enabled = false;
                PlayerStats.Lives = 999;
                GameWonUI.SetActive(true);

            }
        }

       // Debug.Log("Awake");
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
