using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class Menu : NetworkBehaviour
{

    public GameObject CanvasChoose;
    public GameObject Lantern;

    private bool startOn;
    private bool chooseOn;

    // Start is called before the first frame update
    void Start()
    {
        startOn = false;
        chooseOn = false;
        CanvasChoose.SetActive(false);

        InvokeRepeating("SpawnLantern", 16, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && HasStateAuthority)
        {
            Quit();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Directions();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;     
#else
        Application.Quit();
#endif
    }

    public void Directions() // pauses as soon as directions pop up!
    {
        chooseOn = !chooseOn;
        CanvasChoose.SetActive(chooseOn);
        if (CanvasChoose.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SpawnLantern()
    {
        int x = Random.Range(-30, 8);
        int z = Random.Range(0, 13);
        Instantiate(Lantern, new Vector3(x, 3, z), Quaternion.identity);
    }


}