using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject weaponManager = null;
    [SerializeField] private GameObject player = null;


    public void Weapon1()
    {
        weaponManager.GetComponent<WeaponManager>().whipLevel += 1;
        CloseUpgradeMenu();
    }

    public void Weapon2()
    {
        weaponManager.GetComponent<WeaponManager>().santaLevel += 1;
        CloseUpgradeMenu();
    }

    public void Heal()
    {
        float maxHp = player.GetComponent<PlayerManager>().maxHealth;
        player.GetComponent<PlayerManager>().currentHealth = maxHp;
        CloseUpgradeMenu();
    }


    private void CloseUpgradeMenu()
    {
        Time.timeScale = 1;
    }
}
