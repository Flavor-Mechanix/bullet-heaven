using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernalBolt : MonoBehaviour
{
    
    public Rigidbody2D rb;

    [Header("Weapon Stats")]
    public float speed;
    public float baseWeaponDamage;
    public float cooldown;
    public float castLength;
    
    //Internal variables
    private float time = 0;
    public float weaponDamage;
    public int level = 0;


    private void Start()
    {
        float shortestDist = 100000;
        GameObject nearestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            float enemyDist = Mathf.Abs(Vector3.Distance(this.transform.position, enemies[i].transform.position));
            if (enemyDist < shortestDist)
            {
                shortestDist = enemyDist;
                nearestEnemy = enemies[i];
            }
        }

        Vector3 dirToShoot = nearestEnemy.transform.position - this.transform.position;


        //Key line that shoots thing in a given direction
        rb.velocity = dirToShoot * speed;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > castLength)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make enemies take damage
        if (collision.gameObject.TryGetComponent<EnemyManager>(out EnemyManager enemyComponent))
        {
            enemyComponent.TakeDamage(weaponDamage);
            Destroy(this.gameObject);
        }
    }
}
