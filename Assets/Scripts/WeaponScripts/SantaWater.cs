using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWater : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float baseWeaponDamage;
    public float cooldown;
    public float baseCastLength;
    public float castLength;
    public int level;
    public float spawnRadius;
    //Internal variables
    private float time = 0;
    private Vector3 baseScale = new(4.0f, 4.0f, 0);
    
    public string nameTooltip = "Satan water";
    public string levelUpTooltip;
    [HideInInspector] public float weaponDamage;

    private void Start()
    {
        baseScale = new(4.0f, 4.0f, 0);
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
                weaponDamage = 0;
                this.transform.localScale = baseScale;

                levelUpTooltip = "Generates damaging zones.";
                break;
            case 1:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale = baseScale;


                levelUpTooltip = "Fires 1 more projectile. Base area up by 20%.";
                break;
            case 2:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale = baseScale * 1.2f;


                levelUpTooltip = "Base damage up by 10. Effect lasts 0.5 seconds longer.";
                break;
            case 3:
                weaponDamage = baseWeaponDamage + 10;
                castLength = baseCastLength + 0.5f;
                this.transform.localScale = baseScale * 1.2f;


                levelUpTooltip = "Fires 1 more projectile. Base area up by 20%.";
                break;
            case 4:
                weaponDamage = baseWeaponDamage + 10;
                castLength = baseCastLength + 0.5f;
                this.transform.localScale = baseScale * 1.4f;


                levelUpTooltip = "Base damage up by 10. Effect lasts 0.3 seconds longer.";
                break;
            case 5:
                weaponDamage = baseWeaponDamage + 20;
                castLength = baseCastLength + 0.8f;
                this.transform.localScale = baseScale * 1.4f;

                levelUpTooltip = "Fires 1 more projectile. Base area up by 20%.";
                break;
            case 6:
                weaponDamage = baseWeaponDamage + 20;
                castLength = baseCastLength + 0.8f;
                this.transform.localScale = baseScale * 1.6f;


                levelUpTooltip = "Base damage up by 5. Effect lasts 0.3 seconds longer.";
                break;
            case 7:
                weaponDamage = baseWeaponDamage + 25;
                castLength = baseCastLength + 1.1f;
                this.transform.localScale = baseScale * 1.6f;

                levelUpTooltip = "Base damage up by 5. Base area up by 20%.";
                break;
            case 8:
                weaponDamage = baseWeaponDamage + 30;
                castLength = baseCastLength + 1.1f;
                this.transform.localScale = baseScale * 1.8f;

                levelUpTooltip = "Max level.";
                break;
        }

        return levelUpTooltip;

    }



}
