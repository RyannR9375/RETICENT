using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stranger : MonoBehaviour { 

    public float speed;
    public GameObject playerTransform;
    public float talkingDistance;
    private float take;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("player is null");
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Debug.Log("FixedUpdateWorks");
        if (Vector2.Distance(transform.position, transform.position) < talkingDistance) //fix FIX FIX FIX FIX
        {
            Debug.Log("Works");
            Debug.Log(": " + moveSpots + "movespots");
            Debug.Log(": "+ randomSpot + "randomspots");
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        }
    }

    //public void FollowMe()
    //{
            //if (Vector2.Distance(transform.position, player.position) < talkingDistance)
            //{
               // transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
           // }
    //}
}
