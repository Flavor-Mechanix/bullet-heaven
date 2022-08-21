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

    [HideInInspector] private float time = 0;
    [HideInInspector] public float weaponDamage;
    [HideInInspector] public int level = 0;

    public string nameTooltip = "Infernal Bolt";
    public string levelUpTooltip;

    private void Start()
    {
        SetStats(level);
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

    public string SetStats(int level)
    {
        weaponDamage = baseWeaponDamage + (level * 5);


        switch (level)
        {
            case 0:
                levelUpTooltip = "Fires at the nearest enemy.";
                break;
            case 3:
                levelUpTooltip = "Cooldown reduced by 0.2 seconds.";
                break;
            case 1:
            case 2:
            case 4:
            case 6:
                levelUpTooltip = "Gain additional projectile.";
                break;

            case 5:
                levelUpTooltip = "Base damage up.";
                break;
            case 7:
                levelUpTooltip = "Passes through one more enemy.";
                break;
            case 8:
                levelUpTooltip = "Great job nerd. You've played this too much.";
                break;

        }

        return levelUpTooltip;

    }

}
