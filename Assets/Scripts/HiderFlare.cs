using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class HiderFlare : NetworkBehaviour
{
    public ParticleSystem flare;

    private int limit;
    public int Limit
    {
        get { return limit; }
        set { limit = value; }
    }

    void Start()
    {
        flare.Stop();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && flare != null && Limit < 2)
        {
            flare.Play();
            Limit++;
        }
    }
}
