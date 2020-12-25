using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    [HideInInspector]
    public float speed;

    public float health = 100;
    public int worth = 50;
    public bool isDragon = false;
    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        health -= amount;
        if (health <= 0)
        {
            Die();
        }

    }
    //pct is percentage
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    void Die()
    {
        if(!GameManager.gameIsOver)
        {
            PlayerStats.Money += worth;
        }
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }


}