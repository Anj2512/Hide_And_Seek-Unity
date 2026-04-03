using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hider"))
        {
            float newX = Random.Range(-38f, 5f);
            float newZ = Random.Range(-2f, 13f);

            other.gameObject.transform.position = new Vector3(newX, 3f, newZ);
            Destroy(gameObject);

        }
    }
}
