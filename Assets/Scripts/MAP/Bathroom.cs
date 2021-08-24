using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{
    public PlayerMovement player;

    //Moves this GameObject 2 units a second in the forward direction

    //Upon collision with another GameObject, this GameObject will reverse direction
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.Heal();
        }
    } 
}
