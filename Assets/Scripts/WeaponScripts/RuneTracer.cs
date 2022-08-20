using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTracer : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

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
        float xVal = Random.Range(-1.0f, 1.0f);
        float yVal = Random.Range(-1.0f, 1.0f);
        Vector2 direction = new Vector2(xVal, yVal);
        direction.Normalize();
        rb.velocity = direction * speed;
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
}
