using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpBar : MonoBehaviour
{
    public GameObject player;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        image.fillAmount = player.GetComponent<PlayerManager>().currentExp / player.GetComponent<PlayerManager>().expNeededToLevel;
    }
}
