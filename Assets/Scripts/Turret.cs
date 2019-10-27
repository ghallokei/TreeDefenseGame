using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;
    [SerializeField] private int damage;

    private float lastTimeShot;

    public GameObject bullet;
    public List<Enemy> enemies;

    private Transform target;
    
    public GameObject child;
    private void Start()
    {
        lastTimeShot = Time.time;
    }

    private void Update()

    {
        enemies.ForEach(enemy =>
        {
            if (enemy == null) return;
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < fireRange && lastTimeShot + fireRate < Time.time)
            {
                target = enemy.transform;
                GameObject go = Instantiate(bullet, transform);
                go.transform.position = transform.position + Vector3.up;
                Vector3 direction = enemy.transform.position - transform.position;
                direction.y = 0;
                //child.transform.LookAt(direction);
                go.GetComponent<Bullet>().direction = direction;
                lastTimeShot = Time.time;
            }
        });
        if(!target) return;
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0.0f;
        
        child.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.time * 5);
        
    }
}