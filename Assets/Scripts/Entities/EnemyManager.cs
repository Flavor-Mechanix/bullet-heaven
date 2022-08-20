using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Public vars
    
    public static event Action<EnemyManager> OnEnemyKilled;

    [Header("Enemy info")]
    public Rigidbody2D body;
    public SpriteRenderer image;


    //Enemy health & stats
    [Header("Enemy Stats")]
    public float runSpeed;
    public float currentHealth;
    public float maxHealth;
    public float damage;
    public float expWorth;
    

    //Private vars
    private GameObject player;
    private Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ChasePlayer();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // check if enemy is dead
        if(currentHealth <= 0)
        {
            player.GetComponent<PlayerManager>().currentExp += expWorth;
            Destroy(this.gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    private void ChasePlayer()
    {
        player = GameObject.FindWithTag("Player");
        distance = this.transform.position - player.transform.position;
        body.velocity = Vector3.Normalize(distance) * -runSpeed;

        if (distance.x < 0)
        {
            image.flipX = false;
        }
        else
        {
            image.flipX = true;
        }
    }
}
