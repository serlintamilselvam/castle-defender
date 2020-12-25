using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }
   
    void Update()
    {


        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);
        if(!enemy.isDragon)
        {
            enemy.GetComponent<Animator>().SetBool("Run Forward", true);
        }
        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;

    }
    void GetNextWaypoint()
    {
        //Debug.Log("Inside");
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }
    void EndPath()
    {
        if(PlayerStats.Lives > 0)
        {
            PlayerStats.Lives--;
        }
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}