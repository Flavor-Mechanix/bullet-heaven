using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{

    public GameObject player;
    public GameObject[] weapons;
    public GameObject tickManagement;

    private int currentTick;
    private float[,] unitCircle = { { 1 / 2, Mathf.Sqrt(3) / 2 }, { Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2 }, { Mathf.Sqrt(3) / 2, 1 / 2 } };
    //private float[] cooldowns;
    private float whipCooldown, santaWaterCooldown, boltCooldown;
    // Start is called before the first frame update

    [Header("Weapon Levels")]
    [SerializeField] public int whipLevel = 1;
    [SerializeField] public int santaLevel = 0;
    [SerializeField] public int boltLevel = 0;


    void Start()
    {
        tickManagement.GetComponent<TickManager>().OnTickIncrease += SpawnWeapon;
    }



    void SpawnWeapon(object sender, System.EventArgs e)
    {
        currentTick = tickManagement.GetComponent<TickManager>().tickCount;

        whipCooldown = weapons[0].GetComponent<Whip>().cooldown;
        santaWaterCooldown = weapons[1].GetComponent<SantaWater>().cooldown;
        boltCooldown = weapons[2].GetComponent<InfernalBolt>().cooldown;



        // WHIP FUNCTIONS
        if (currentTick % whipCooldown == 0)
        {
            GameObject weapon = Instantiate(weapons[0], player.transform.position, Quaternion.identity);
            weapon.GetComponent<Whip>().level = whipLevel;

            if (whipLevel >= 5)
            {
                GameObject secondWeapon = Instantiate(weapons[0], player.transform.position, Quaternion.identity);
                Vector3 weaponVector = secondWeapon.transform.localScale;
                weaponVector = new Vector3(weaponVector.x - 200, weaponVector.y, weaponVector.z);

                Vector3 rot = secondWeapon.transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, rot.y + 180, rot.z);
                secondWeapon.transform.rotation = Quaternion.Euler(rot);

                secondWeapon.GetComponent<Whip>().level = whipLevel;
            }
        }

        // SANTAWATER FUNCTIONS
        if (currentTick % santaWaterCooldown == 0)
        {

            Vector2[] spawnVecs = {
                new Vector2(unitCircle[0, 0], unitCircle[0, 1]),new Vector2(unitCircle[1, 0], unitCircle[1, 1]),
                new Vector2(unitCircle[2, 0], unitCircle[2, 1]),new Vector2(-unitCircle[0, 0], unitCircle[0, 1]),
                new Vector2(-unitCircle[1, 0], unitCircle[1, 1]),new Vector2(-unitCircle[2, 0], unitCircle[2, 1]),
                new Vector2(unitCircle[0, 0], -unitCircle[0, 1]),new Vector2(unitCircle[1, 0], -unitCircle[1, 1]),
                new Vector2(unitCircle[2, 0], -unitCircle[2, 1]),new Vector2(-unitCircle[0, 0], -unitCircle[0, 1]),
                new Vector2(-unitCircle[1, 0], -unitCircle[1, 1]),new Vector2(-unitCircle[2, 0], -unitCircle[2, 1])
            };
            List<Vector2> vecList = new List<Vector2>(spawnVecs);

            int u = 0;
            while (u < santaLevel / 2)
            {
                int chosenElement = Random.Range(0, vecList.Count - 1);
                Vector2 chosenVec = vecList[chosenElement];
                vecList.RemoveAt(chosenElement);

                SpawnSanta(santaLevel, chosenVec);
                u++;
            }
        }

        // INFERNAL BOLT FUNCTIONS
        if (currentTick % boltCooldown == 0 & boltLevel > 0)
        {
            GameObject weapon = Instantiate(weapons[2], player.transform.position, Quaternion.identity);
            weapon.GetComponent<InfernalBolt>().level = boltLevel;
        } 
    }




    void SpawnSanta(int level, Vector2 spawnVec)
    {

        spawnVec *=  6;

        GameObject weapon = Instantiate(weapons[1], player.transform.position, Quaternion.identity);
        weapon.transform.position += new Vector3(spawnVec.x, spawnVec.y, 0);
        weapon.GetComponent<SantaWater>().level = level;
    }


    public void UpdateLevels()
    {

    }

}