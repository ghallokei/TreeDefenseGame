using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public Vector3 direction;

    private Vector3 startPos;
    private float timeLeft = 5;
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(bulletSpeed * Time.deltaTime * direction);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            Destroy(this.gameObject);
        }
    }
}