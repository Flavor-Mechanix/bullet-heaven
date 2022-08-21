using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float baseWeaponDamage = 20f;
    public float cooldown = 6f;
    public float castLength = 0.45f;
    public int level = 0;

    //Internal variables

    private float time = 0;
    [HideInInspector] public float weaponDamage;
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
        weaponDamage = baseWeaponDamage + (level * 5);
        // 
        //
        // Debug.Log("Weapon level: " + level);


        switch (level)
        {
            case 0:
                levelUpTooltip = "Attacks horizontally, passes through enemies.";
                break;
            case 1:
            case 2:
                levelUpTooltip = "Gain additional whip. Attack up.";
                break;
            case 4:
            case 6:
                levelUpTooltip = "Size increased. Attack up.";
                this.transform.localScale +=
                    new Vector3(0.5f * level, 0.5f * level, 0.0f);
                break;
            case 3:
            case 5:
            case 7:
            case 8:
                levelUpTooltip = "+5 damage.";
                break;
            
        }

        return levelUpTooltip;

    }

}
