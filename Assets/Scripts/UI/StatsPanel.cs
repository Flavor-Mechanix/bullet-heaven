using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatsPanel : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponController;

    [Header("Text boxes")]
    [SerializeField] private TMP_Text playerLevelText = null;
    [SerializeField] private TMP_Text playerMaxHpText = null;
    [SerializeField] private TMP_Text playerCurHpText = null;
    [SerializeField] private TMP_Text whipLevelText = null;
    [SerializeField] private TMP_Text santaLevelText = null;

    public void UpdateStats()
    {
        int playerLevel = player.GetComponent<PlayerManager>().currentLevel;
        float playerMaxHp = player.GetComponent<PlayerManager>().maxHealth;
        float playerCurHp = player.GetComponent<PlayerManager>().currentHealth;
        int whipLevel = weaponController.GetComponent<WeaponManager>().whipLevel;
        int santaLevel = weaponController.GetComponent<WeaponManager>().santaLevel;

        playerLevelText.SetText(playerLevel.ToString());
        playerMaxHpText.SetText(playerMaxHp.ToString("0"));
        playerCurHpText.SetText(playerCurHp.ToString("0"));
        whipLevelText.SetText(whipLevel.ToString());
        santaLevelText.SetText(santaLevel.ToString());
    }

}
