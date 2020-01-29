﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public enum colliderType { Rock, Scoreable};//... As many as needed

    public colliderType type;
    public PointTracker ptTracker;
    public int scoreOnCollide;
    public float speedMod;
    public Movement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        if(playerMove == null)
            playerMove = FindObjectOfType<Movement>().GetComponent<Movement>();
        if (ptTracker == null)
            ptTracker = FindObjectOfType<PointTracker>().GetComponent<PointTracker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (type == colliderType.Rock)
            {
                Debug.Log("INSIDE");
                //slow down until exit
                playerMove.ModifySpeed(speedMod);
            }
            else if(type == colliderType.Scoreable)
            {
                //add score
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (type == colliderType.Rock)
            {
                //speed back up
                playerMove.ModifySpeed(1f);
            }
        }
    }
}