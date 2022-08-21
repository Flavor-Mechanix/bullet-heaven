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
    private float whipCooldown, santaWaterCooldown, boltCooldown, orbCooldown;
    // Start is called before the first frame update

    [Header("Weapon Levels")]
    [SerializeField] public int whipLevel = 1;
    [SerializeField] public int santaLevel = 0;
    [SerializeField] public int boltLevel = 0;
    [SerializeField] public int orbLevel = 0;

    public string whipTooltip = null;
    public string satanTooltip = null;
    public string boltTooltip = null;
    public string orbTooltip = null;

    void Start()
    {
        tickManagement.GetComponent<TickManager>().OnTickIncrease += SpawnWeapon;
    }

    private void LateUpdate()
    {
        CheckForMaxLevels();
    }

    // main logic for spawning the various weapons
    void SpawnWeapon(object sender, System.EventArgs e)
    {
        currentTick = tickManagement.GetComponent<TickManager>().tickCount;

        whipCooldown = weapons[0].GetComponent<Whip>().cooldown;
        whipTooltip = weapons[0].GetComponent<Whip>().SetStats(whipLevel);

        santaWaterCooldown = weapons[1].GetComponent<SantaWater>().cooldown;
        satanTooltip = weapons[1].GetComponent<SantaWater>().SetStats(santaLevel);

        boltCooldown = weapons[2].GetComponent<InfernalBolt>().cooldown;
        boltTooltip = weapons[2].GetComponent<InfernalBolt>().SetStats(boltLevel);

        orbCooldown = weapons[3].GetComponent<Orbital>().cooldown;
        orbTooltip = weapons[3].GetComponent<Orbital>().SetStats(orbLevel);



        // WHIP FUNCTIONS
        if (currentTick % whipCooldown == 0 & whipLevel > 0)
        {
            GameObject weapon = Instantiate(weapons[0], player.transform.position, Quaternion.identity);
            weapon.GetComponent<Whip>().level = whipLevel;

            if (whipLevel > 1)
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


        // SATANWATER FUNCTIONS
        if (currentTick % santaWaterCooldown == 0 & santaLevel > 0)
        {
            //Determine the number of spawns needed
            

            //Initialize the list of potential unit veectors
            Vector2[] spawnVecs = {
                new Vector2(unitCircle[0, 0], unitCircle[0, 1]),new Vector2(unitCircle[1, 0], unitCircle[1, 1]),
                new Vector2(unitCircle[2, 0], unitCircle[2, 1]),new Vector2(-unitCircle[0, 0], unitCircle[0, 1]),
                new Vector2(-unitCircle[1, 0], unitCircle[1, 1]),new Vector2(-unitCircle[2, 0], unitCircle[2, 1]),
                new Vector2(unitCircle[0, 0], -unitCircle[0, 1]),new Vector2(unitCircle[1, 0], -unitCircle[1, 1]),
                new Vector2(unitCircle[2, 0], -unitCircle[2, 1]),new Vector2(-unitCircle[0, 0], -unitCircle[0, 1]),
                new Vector2(-unitCircle[1, 0], -unitCircle[1, 1]),new Vector2(-unitCircle[2, 0], -unitCircle[2, 1])
            };
            List<Vector2> vecList = new(spawnVecs);

            //more explicit and less editable but still easy to edit and less prone to bugs
            int numSpawns = 1;
            if (santaLevel > 1) { numSpawns += 1; }
            if (santaLevel > 3) { numSpawns += 1; }
            if (santaLevel > 5) { numSpawns += 1; }

            int u = 0;
            while (u < numSpawns)
            {
                int chosenElement = Random.Range(0, vecList.Count - 1);
                Vector2 chosenVec = vecList[chosenElement];
                vecList.RemoveAt(chosenElement);


                // put all functions here
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


        // ORB FUNCTIONS
        if (currentTick % orbCooldown == 0 & orbLevel > 0)
        {
            GameObject weapon = Instantiate(weapons[3], player.transform.position, Quaternion.identity);
            weapon.GetComponent<Orbital>().level = orbLevel;
        }
    }






    // Helper functions
    void SpawnSanta(int level, Vector2 spawnVec)
    {

        
        //spawn the weapon
        GameObject weapon = Instantiate(weapons[1], player.transform.position, Quaternion.identity);

        // do transforms and stat adjustments to the weapon
        spawnVec *= weapon.GetComponent<SantaWater>().spawnRadius;
        weapon.transform.position += new Vector3(spawnVec.x, spawnVec.y, 0);
        weapon.GetComponent<SantaWater>().level = santaLevel;
    }




    void CheckForMaxLevels()
    {
        if (whipLevel > 8) { whipLevel = 8; }
        if (santaLevel > 8) { santaLevel = 8; }
        if (boltLevel > 8) { boltLevel = 8; }
        if (orbLevel > 8) { orbLevel = 8; }
    }

}