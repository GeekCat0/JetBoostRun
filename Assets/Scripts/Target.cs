using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public int points = 1;
    public GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    
    public void TakeDamage(float amount)
    { 
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        manager.AddCoins(points);
    }
}
