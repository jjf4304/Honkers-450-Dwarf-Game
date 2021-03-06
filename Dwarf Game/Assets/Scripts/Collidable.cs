﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public enum colliderType { Rock, Scoreable, PickUp};//... As many as needed

    public colliderType type;
    public PointTracker ptTracker;
    public EnergyBar energyBar;
    public int scoreOnCollide;
    public float speedMod;
    public int energyAddAmount;
    public Movement playerMove;
    private bool scored;

    // Start is called before the first frame update
    void Start()
    {
        if(playerMove == null)
            playerMove = FindObjectOfType<Movement>().GetComponent<Movement>();
        if (ptTracker == null)
            ptTracker = FindObjectOfType<PointTracker>().GetComponent<PointTracker>();
        if (energyBar == null)
            energyBar = FindObjectOfType<EnergyBar>().GetComponent<EnergyBar>();
        scored = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Block"))
        {
            transform.position = new Vector3(Random.Range(-7, 7), transform.position.y + Random.Range(-3, 3), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (type == colliderType.Rock)
            {
                //slow down until exit
                playerMove.ModifySpeed(speedMod);
            }
            else if(type == colliderType.Scoreable && !scored)
            {
                //add score
                
                scored = true;
                ptTracker.AddScore(scoreOnCollide);

                GetComponent<AudioSource>().Play();

                //Temp way to get rid of scoreable
                gameObject.transform.position = new Vector3(-100, 0, 0);

            }
            else if(type == colliderType.PickUp)
            {
                energyBar.AddEnergy(energyAddAmount);
                gameObject.transform.position = new Vector3(-100, 0, 0);
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
