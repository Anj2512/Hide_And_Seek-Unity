using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;     //quits without build & run
#else
        Application.Quit();
#endif
    }

}
