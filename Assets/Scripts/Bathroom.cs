using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{
    public PlayerMovement player;

    public int HealTimes = 2;
    public bool canHeal;
    [SerializeField] int HealTimeValue = -1;

    //Moves this GameObject 2 units a second in the forward direction

    //Upon collision with another GameObject, this GameObject will reverse direction
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && canHeal == true)
        {
            player.Heal();
            GameManager.MyInstance.HealTimesUI(HealTimeValue);

        }
    }

    private void FixedUpdate()
    {
        if (player.currentHealth == player.maxHealth)
        {
            canHeal = false;
        }
        else if (player.currentHealth != player.maxHealth)
        {
            canHeal = true;
        }

        
            if (canHeal == false)
            {

                //HealTimes = HealTimes;

            }

            else if (canHeal == true)
            {

                if (HealTimes < 0)
                {
                    HealTimes = 0;
                }
            }

        }
    }

