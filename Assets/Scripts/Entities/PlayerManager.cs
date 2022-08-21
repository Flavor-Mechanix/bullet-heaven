using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    //Public parameters
    [Header("Player Stats")]
    public float currentHealth;
    public float maxHealth = 100f;
    public float currentExp = 0;
    public float expNeededToLevel = 5;
    public float levelScaler = 1.2f;
    public int currentLevel = 1;
    public int maxLevel = 20;
    public string loseScene;

    public AudioClip levelupDiddle;

    [Header("Interactions")]
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject statsMenu;


    //Private parameters
    private float damage;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentExp >= expNeededToLevel & currentLevel <= maxLevel)
        {
            //Level up methods
            currentLevel += 1; //Incease current level
            Time.timeScale = 0; //Pause game
            upgradeMenu.SetActive(true); //turn on the upgrade menu
            statsMenu.SetActive(true); //turn on stats menu
            statsMenu.GetComponent<StatsPanel>().UpdateStats();

            //Reset level and increase xp needed for next level
            currentExp = 0;
            expNeededToLevel = levelScaler*expNeededToLevel + 5;
            AudioSource.PlayClipAtPoint(levelupDiddle, this.transform.position);
            //Change weapon stats
            
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(loseScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            damage = collision.GetComponent<EnemyManager>().damage;
            currentHealth -= damage;
        }
    }

    //void OnGUI()
    //{
    //    Event currentEvent = Event.current;

    //    GUILayout.BeginArea(new Rect(20, 20, 250, 120));

    //    GUILayout.Label("Level: " + currentLevel); //shows level

    //    GUILayout.EndArea();
    //} //debug time
}