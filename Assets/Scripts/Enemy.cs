using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public ForestManager forest;
    
    public int health;
    private void Start()
    {
        health = 100;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GameObject target = forest.getClosestTree(transform.position);
        agent.SetDestination(target.transform.position);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 1.5)
        {
            target.GetComponent<Tree>().dealDamage(50);
            health = -1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            takedamage(40);
        }
    }

    public void takedamage(int amount)
    {
        health -= amount;
    }

    public int getHealth()
    {
        return health;
    }
}