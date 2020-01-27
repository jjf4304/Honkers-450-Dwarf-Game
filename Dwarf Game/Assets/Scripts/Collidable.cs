using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public enum colliderType { Rock, Scoreable};//... As many as needed

    public colliderType type;
    public int score;
    public float speedMod;
    public Movement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<Movement>().GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("player"))
        {
            if (type == colliderType.Rock)
            {
                

            }
            else if(type == colliderType.Scoreable)
            {
                //add score

            }
        }
    }
}
