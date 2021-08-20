﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] int itemValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collected();
        }
    }



    protected virtual void Collected()
    {
        //override
        Destroy(this.gameObject);
    }
    
}
