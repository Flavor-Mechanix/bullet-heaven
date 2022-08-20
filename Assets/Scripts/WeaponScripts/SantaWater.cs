using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWater : MonoBehaviour
{
    public float baseWeaponDamage = 20f;
    public float cooldown = 6f;
    public float castLength = 0.45f;
    public int level = 0;

    //Internal variables
    private float time = 0;
    public float weaponDamage;
    private float scaleChange;

    private void Start()
    {
        SetStats();
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

    public void SetStats()
    {
        weaponDamage = baseWeaponDamage + (level * 5);
        // scaleChange = level * 0.05f;
        //this.transform.localScale += new Vector3(0.5f * level, 0.5f * level, 0.0f);
        // Debug.Log("Weapon level: " + level);
    }



}
