using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class SeekerScript : NetworkBehaviour
{

    public GameObject projectile;
    public Transform spawnpt;

    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z) && HasStateAuthority)
        {
            GameObject curr = Instantiate(projectile, spawnpt.position, spawnpt.rotation);
            curr.GetComponent<Rigidbody>().AddForce(spawnpt.transform.forward * 200f, ForceMode.Impulse);
        }
    }
}

