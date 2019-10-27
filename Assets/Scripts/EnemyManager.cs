using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public ForestManager forest;
    public List<Enemy> enemies = new List<Enemy>();

    public float timer = 45;

    public PlayerController player;

    public Text timerText;

    private int currentWave;

    public ParticleSystem dedEffect;
    private void Update()
    {
        CheckForDeadGhosts();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            currentWave++;
            StartCoroutine(spawnEnemy(20 * currentWave, 2/ currentWave , 3/ currentWave));


            timer = 80;
        }

        if (currentWave == 0)
        {
            timerText.text = "Set up your defenses before the first wave starts in: " + Mathf.Round(timer);
        }
        else
        {
            timerText.text = "Wave " + currentWave + " has started! Keep all your Trees alive! Clear the enemies in: " +
                             Mathf.Round(timer);
        }
    }

    private void Start()
    {
    }

    private IEnumerator spawnEnemy(int enemyAmount, float minTime, float maxTime)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject go = Instantiate(enemy , transform);
            enemies.Add(go.GetComponent<Enemy>());
            Vector3 pos = new Vector3(-10, 0, Random.Range(30, 7));
            go.transform.position = pos;
            go.GetComponent<Enemy>().forest = forest;
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    private void CheckForDeadGhosts()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].getHealth() <= 0)
            {
                Vector3 location = new Vector3(enemies[i].gameObject.transform.position.x, enemies[i].gameObject.transform.position.y,enemies[i].gameObject.transform.position.z);
                ParticleSystem effect = GameObject.Instantiate(dedEffect);
                effect.transform.position = location;
                player.AddEP();
                player.AddPoints(10);
                PlayerController.Destroy(enemies[i].gameObject);
                enemies.Remove(enemies[i]);
            }
        }
    }
}