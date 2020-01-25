using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public Rigidbody2D rigid;
    public GameObject cam;
    private float offset;
    public float downSpeed;
    public float sideSpeed;
    public List<GameObject> trailObjects;

    int trailIndex;
    float rotateShipBy = 0;
    const float rotationAmount = 1.0f;
    const float maxRot = .2f;

    // Start is called before the first frame update
    void Start()
    {
        downSpeed = -10f;
        sideSpeed = 0f;
        rigid = GetComponent<Rigidbody2D>();
        offset = transform.position.y - cam.transform.position.y;
        trailIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleTrail();
        //Vector3 vec = new Vector3(rigid.velocity.x, rigid.velocity.y, 0f);
    }

    // Places and moves the trail as the player moves
    void HandleTrail()
    {
        Debug.Log(trailIndex);
        trailObjects[trailIndex].transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        trailObjects[trailIndex].transform.rotation = transform.rotation;
        if (trailIndex == trailObjects.Count - 1)
        {
            trailIndex = 0;
        }
        else
        {
            trailIndex++;
        }
    }

    // Takes care of all side to side movement and rotations
    void HandleMovement()
    {
        cam.transform.position = new Vector3(0, transform.position.y - offset, cam.transform.position.z);
        sideSpeed = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            sideSpeed = -5f;
            rotateShipBy = -rotationAmount;
            if (transform.rotation.z < -maxRot)
            {
                rotateShipBy = 0;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sideSpeed = 5f;
            rotateShipBy = rotationAmount;
            if (transform.rotation.z > maxRot)
            {
                rotateShipBy = 0;
            }
        }
        else
        {
            if (transform.rotation.z > .01f)
            {
                rotateShipBy = -rotationAmount;
            }
            else if (transform.rotation.z < -.01f)
            {
                rotateShipBy = rotationAmount;
            }
            else
            {
                rotateShipBy = 0;
            }
        }
        transform.Rotate(new Vector3(0f, 0f, rotateShipBy));
        rotateShipBy = 0;
        rigid.velocity = new Vector2(sideSpeed, downSpeed);
    }
}
