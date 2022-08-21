using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject weaponManager = null;
    [SerializeField] private GameObject player = null;

    [Header("Text")]
    private GameObject[] weapons = null;
    private List<GameObject> weaponList = null;

    private GameObject weapon1 = null;
    private GameObject weapon2 = null;
    private GameObject weapon3 = null;

    [Header("Text boxes")]
    [SerializeField] public TMP_Text weapon1NameText = null;
    [SerializeField] public TMP_Text weapon2NameText = null;
    [SerializeField] public TMP_Text weapon3NameText = null;

    [SerializeField] public TMP_Text weapon1Tooltip = null;
    [SerializeField] public TMP_Text weapon2Tooltip = null;
    [SerializeField] public TMP_Text weapon3Tooltip = null;

    [SerializeField] public TMP_Text weapon1Level = null;
    [SerializeField] public TMP_Text weapon2Level = null;
    [SerializeField] public TMP_Text weapon3Level = null;

    [Header("Debugging")]
    [HideInInspector] public int index;

    void OnEnable()
    {

        // weaponManager.GetComponent<WeaponManager>().SetToolTips();

        weapons = weaponManager.GetComponent<WeaponManager>().weapons;
        weaponList = weapons.ToList();

        // This is basically repeated 3 times for each button on the UI... there's definitely a better way to do this -_(o.o)_-
        // Will need a better solution for a game with additional complexity. The nice thing is that it doesn't really matter how many weapons there are, just how many buttons here
        index = Random.Range(0, weaponList.Count);
        weapon1 = GetWeapon(index);
        weapon1Level.SetText(GetWeaponLevel(weapon1));
        weapon1Tooltip.SetText(GetWeaponTooltip(weapon1));
        weapon1NameText.SetText(GetWeaponName(weapon1));


        weaponList.RemoveAt(index);


        index = Random.Range(0, weaponList.Count);
        weapon2 = GetWeapon(index);
        weapon2Level.SetText(GetWeaponLevel(weapon2));
        weapon2Tooltip.SetText(GetWeaponTooltip(weapon2));
        weapon2NameText.SetText(GetWeaponName(weapon2));

        weaponList.RemoveAt(index);


        index = Random.Range(0, weaponList.Count);
        weapon3 = GetWeapon(index);
        weapon3Level.SetText(GetWeaponLevel(weapon3));
        weapon3Tooltip.SetText(GetWeaponTooltip(weapon3));
        weapon3NameText.SetText(GetWeaponName(weapon3));

    }



    //Methods to set the text box with relevant information

    public GameObject GetWeapon(int index)
    {
        
        GameObject weapon = weaponList[index];
        return weapon;
    }

    public string GetWeaponTooltip(GameObject weapon)
    {
        string toolTip = null;

        if (weapon.TryGetComponent<Whip>(out Whip whip))
        {
            toolTip = weapon.GetComponent<Whip>().levelUpTooltip;
        }

        else if (weapon.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            toolTip = weapon.GetComponent<SantaWater>().levelUpTooltip;
        }

        else if (weapon.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            toolTip = weapon.GetComponent<InfernalBolt>().levelUpTooltip;
        }

        else if (weapon.TryGetComponent<Orbital>(out Orbital orbital))
        {
            toolTip = weapon.GetComponent<Orbital>().levelUpTooltip;
        }


        return toolTip;
    }

    public string GetWeaponName(GameObject weapon)
    {
        string name = null;

        if (weapon.TryGetComponent<Whip>(out Whip whip))
        {
            name = weapon.GetComponent<Whip>().nameTooltip;
        }

        else if (weapon.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            name = weapon.GetComponent<SantaWater>().nameTooltip;
        }

        else if (weapon.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            name = weapon.GetComponent<InfernalBolt>().nameTooltip;
        }

        else if (weapon.TryGetComponent<Orbital>(out Orbital orbital))
        {
            name = weapon.GetComponent<Orbital>().nameTooltip;
        }

        return name;
    }

    private string GetWeaponLevel(GameObject weapon)
    {
        int weaponLevel = 0;


        if (weapon.TryGetComponent<Whip>(out Whip whip))
        {
            weaponLevel = weaponManager.GetComponent<WeaponManager>().whipLevel;
        }

        else if (weapon.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            weaponLevel = weaponManager.GetComponent<WeaponManager>().santaLevel;
        }

        else if (weapon.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            weaponLevel = weaponManager.GetComponent<WeaponManager>().boltLevel;
        }

        else if (weapon.TryGetComponent<Orbital>(out Orbital orbital))
        {
            weaponLevel = weaponManager.GetComponent<WeaponManager>().orbLevel;
        }

        return weaponLevel.ToString();
    }



    // Static heal button

    public void Heal()
    {
        float maxHp = player.GetComponent<PlayerManager>().maxHealth;
        player.GetComponent<PlayerManager>().currentHealth = maxHp;
        CloseUpgradeMenu();
    }


    // Method for starting back up the game

    public void CloseUpgradeMenu()
    {
        Time.timeScale = 1;
    }







    // really really really bad code but idgaf

    public void UpgradeWeapon1()
    {

        if (weapon1.TryGetComponent<Whip>(out Whip whip))
        {
            weaponManager.GetComponent<WeaponManager>().whipLevel += 1;
        }

        else if (weapon1.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            weaponManager.GetComponent<WeaponManager>().santaLevel += 1;
        }

        else if (weapon1.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            weaponManager.GetComponent<WeaponManager>().boltLevel += 1;
        }

        else if (weapon1.TryGetComponent<Orbital>(out Orbital orbital))
        {
            weaponManager.GetComponent<WeaponManager>().orbLevel += 1;
        }
    }

    public void UpgradeWeapon2()
    {

        if (weapon2.TryGetComponent<Whip>(out Whip whip))
        {
            weaponManager.GetComponent<WeaponManager>().whipLevel += 1;
        }

        else if (weapon2.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            weaponManager.GetComponent<WeaponManager>().santaLevel += 1;
        }

        else if (weapon2.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            weaponManager.GetComponent<WeaponManager>().boltLevel += 1;
        }

        else if (weapon2.TryGetComponent<Orbital>(out Orbital orbital))
        {
            weaponManager.GetComponent<WeaponManager>().orbLevel += 1;
        }
    }

    public void UpgradeWeapon3()
    {

        if (weapon3.TryGetComponent<Whip>(out Whip whip))
        {
            weaponManager.GetComponent<WeaponManager>().whipLevel += 1;
        }

        else if (weapon3.TryGetComponent<SantaWater>(out SantaWater santaWater))
        {
            weaponManager.GetComponent<WeaponManager>().santaLevel += 1;
        }

        else if (weapon3.TryGetComponent<InfernalBolt>(out InfernalBolt infernalBolt))
        {
            weaponManager.GetComponent<WeaponManager>().boltLevel += 1;
        }

        else if (weapon3.TryGetComponent<Orbital>(out Orbital orbital))
        {
            weaponManager.GetComponent<WeaponManager>().orbLevel += 1;
        }
    }

    
}
