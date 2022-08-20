using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickManager : MonoBehaviour
{
    public event EventHandler OnTickIncrease;
    public int tickCount;
    public int winTime = 120;
    public string winScene;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TickIncrease",0f,(1f/2f));
    }

    void TickIncrease()
    {
        tickCount++;
        // print("The current tick is: " + tickCount);
        OnTickIncrease?.Invoke(this, EventArgs.Empty);

        if (tickCount >= winTime)
        {
            WinCondition();
        }

    }

    private void WinCondition()
    {
        SceneManager.LoadScene(winScene);
    }
}
