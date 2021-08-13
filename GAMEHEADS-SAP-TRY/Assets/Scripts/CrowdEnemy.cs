using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdEnemy : MonoBehaviour
{

    public Transform player;

    public float talkingDistance;
    public GameObject TextUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < talkingDistance)
        {

        }
    }
}
