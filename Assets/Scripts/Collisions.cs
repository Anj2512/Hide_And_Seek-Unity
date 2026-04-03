using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            print("flooring!"); 
            Destroy(gameObject);
        }
        if (other.CompareTag("Hider"))
        {
            Destroy(other.gameObject);
            Time.timeScale = 0f;
            
            SceneManager.LoadScene("HiderLostScene");
        }
    }
}
