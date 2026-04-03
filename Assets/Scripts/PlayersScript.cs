using System.Collections;
using System.Collections.Generic;
using TMPro;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersScript : NetworkBehaviour
{
    private int best = -1;

    public TMP_Text timerText;
    public TMP_Text bestText;


    public GameObject wall1; public GameObject wall2; public GameObject wall3; public GameObject wall4;

    int t = 15;

    private bool justonce;
    public bool JustOnce
    {
        get { return justonce; }
        set { justonce = value; }
    }

    private bool des;
    public bool Des
    {
        get { return des; }
        set { des = value; }
    }

    private int timer;
    public int Timer
    {
        get { return timer; }
        set { timer = value; }
    }

    
    public override void Spawned()
    {
        best = PlayerPrefs.GetInt("Best", -1);
        if (best != -1)
        {
            bestText.text = "Best Time: " + best + "s";
        }

        StartCoroutine(StartCountdown(15));
    }


    public IEnumerator StartCountdown(int startT)
    {
        if (!JustOnce)
        {
            timer = startT;

            while (timer > 0)
            {
                yield return new WaitForSeconds(1.0f);  // from FruitNinja
                timer--;
                timerText.text = "Timer: " + timer;
            }
            if (timer == 0 && !Des && !JustOnce)
            {
                Destroy(wall1);
                Destroy(wall2);
                Destroy(wall3);
                Destroy(wall4);
                des = true;
            }
            StartCoroutine(StartCountdown(60));
            JustOnce = true;
        }
        if(JustOnce && timer == 0)
        {
            SceneManager.LoadScene("SeekerLostScene");
        }

    }

}

