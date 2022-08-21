using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital : MonoBehaviour
{

    // public Rigidbody2D rb;
    [HideInInspector] public Transform target;

    [Header("Weapon Stats")]
    public float baseWeaponDamage;
    public float cooldown;
    public float castLength;
    public float RotationSpeed = 1;
    public float CircleRadius = 1;

    //Internal variables
    
    private float time = 0;
    [HideInInspector] public float weaponDamage;
    [HideInInspector] public int level = 0;

    public string nameTooltip = "Sigil's Shepherd";
    public string levelUpTooltip;

    // Drag & drop the player in the inspector
    private readonly float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;


    private void Start()
    {
        SetStats(level);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            ElevationOffset
        );

        transform.position = target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;

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
                levelUpTooltip = "Passes through enemies, bounces around";
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
                levelUpTooltip = "Effect lasts .5 seconds longer.";
                break;

        }

        return levelUpTooltip;

    }

}
