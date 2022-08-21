using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernalBolt : MonoBehaviour
{
    
    public Rigidbody2D rb;

    [Header("Weapon Stats")]
    public float speed;
    public float baseWeaponDamage;
    public float baseCooldown;
    [System.NonSerialized] public float cooldown;
    [System.NonSerialized] private int enemiesToPass = 1;
    [System.NonSerialized] private int enemiesPassed = 0;
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
            enemiesPassed += 1;
            if (enemiesPassed > enemiesToPass) { Destroy(this.gameObject); }
        }
    }

    public string SetStats(int level)
    {
        weaponDamage = baseWeaponDamage + (level * 5);


        switch (level)
        {
            case 0:
                weaponDamage = 0;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 1;
                levelUpTooltip = "Fires at the nearest enemy.";
                break;
            case 1:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 1;
                levelUpTooltip = "Passes through 1 more enemy.";
                break;
            case 2:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 2;
                levelUpTooltip = "Cooldown reduced by 0.2 seconds.";
                break;
            case 3:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown - 0.2f;
                enemiesToPass = 2;
                levelUpTooltip = "Passes through 1 more enemy.";
                break;
            case 4:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 3;
                levelUpTooltip = "Base damage up by 10.";
                break;
            case 5:
                weaponDamage = baseWeaponDamage + 10;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 3;
                levelUpTooltip = "Passes through 1 more enemy.";
                break;
            case 6:
                weaponDamage = baseWeaponDamage + 10;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 4;
                levelUpTooltip = "Passes through 1 more enemy.";
                break;
            case 7:
                weaponDamage = baseWeaponDamage + 10;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                enemiesToPass = 5;
                levelUpTooltip = "Base damage up by 10.";
                break;
            case 8:
                weaponDamage = baseWeaponDamage + 20;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown * 0.5f;
                levelUpTooltip = "Max level.";
                break;
        }

        return levelUpTooltip;

    }

}
