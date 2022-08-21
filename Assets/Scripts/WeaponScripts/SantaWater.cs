using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWater : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float baseWeaponDamage = 20f;
    public float cooldown = 6f;
    public float castLength = 0.45f;
    public int level = 0;
    public float spawnRadius = 10f;
    //Internal variables
    private float time = 0;
    
    public string nameTooltip = "Satan water";
    public string levelUpTooltip;
    [HideInInspector] public float weaponDamage;

    private void Start()
    {
        SetStats(level);
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
        }
    }

    public string SetStats(int level)
    {
        weaponDamage = baseWeaponDamage + (level * 5);


        switch (level)
        {
            case 0:
                levelUpTooltip = "Generates damaging zones.";
                break;
            case 3:
                levelUpTooltip = "Base damage up. Effect lasts 0.5 seconds longer.";
                break;
            case 1:
            case 2:
            case 4:
            case 6:
            case 8:
                levelUpTooltip = "Gain additional projectile. Area up.";
                levelUpTooltip = "Size increased. Attack up.";
                this.transform.localScale +=
                    new Vector3(0.2f * level, 0.2f * level, 0.0f);
                break;
            
            case 5:
            case 7:
                levelUpTooltip = "Base damage up. Effect lasts 0.3 seconds longer.";
                break;

        }

        return levelUpTooltip;

    }



}
