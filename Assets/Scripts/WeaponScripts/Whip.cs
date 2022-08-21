using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float baseWeaponDamage = 20f;
    public float baseCooldown = 6f;
    public float cooldown;
    public float castLength = 0.45f;
    public int level = 0;

    //Internal variables

    private float time = 0;
    [System.NonSerialized] public float weaponDamage;
    private int maxLevel = 8;
    public string levelUpTooltip;
    public string nameTooltip = "Abyssal Whip";


    private void Start()
    {
        if (level > maxLevel) { level = maxLevel; }
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
       //This is kind of confusing because weapon stats are based on current level, tooltip is for NEXT level
        switch (level)
        {
            case 0:
                weaponDamage = 0;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Attacks horizontally, passes through enemies.";
                break;
            case 1:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Gain additional whip.";
                break;
            case 2:
                weaponDamage = baseWeaponDamage;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Base damage up by 5.";
                break;
            case 3:
                weaponDamage = baseWeaponDamage + 5;
                this.transform.localScale =
                    new Vector3(1.0f, 1.0f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Base damage up by 5. Base area up by 10%.";
                break;
            case 4:
                weaponDamage = baseWeaponDamage + 10;
                this.transform.localScale =
                    new Vector3(1.1f, 1.1f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Base damage up by 5.";
                break;
            case 5:
                weaponDamage = baseWeaponDamage + 15;
                this.transform.localScale =
                    new Vector3(1.1f, 1.1f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Base damage up by 5. Base area up by 10%.";
                break;
            case 6:
                weaponDamage = baseWeaponDamage + 20;
                this.transform.localScale =
                    new Vector3(1.2f, 1.2f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "+5 damage.";
                break;
            case 7:
                weaponDamage = baseWeaponDamage + 25;
                this.transform.localScale =
                    new Vector3(1.2f, 1.2f, 0.0f);
                cooldown = baseCooldown;
                levelUpTooltip = "Attacks twice as fast.";
                break;
            case 8:
                weaponDamage = baseWeaponDamage + 25;
                this.transform.localScale =
                    new Vector3(1.2f, 1.2f, 0.0f);
                cooldown = baseCooldown * 0.5f;
                levelUpTooltip = "Max level.";
                break;
        }

        return levelUpTooltip;

    }

}
