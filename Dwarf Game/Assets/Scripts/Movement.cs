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
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(0, transform.position.y - offset, cam.transform.position.z);
        sideSpeed = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            sideSpeed = -5f;
            rotateShipBy = -rotationAmount;
            if(transform.rotation.z < -maxRot)
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
        print(transform.rotation.z);
        rotateShipBy = 0;
        rigid.velocity = new Vector2(sideSpeed, downSpeed);
        Vector3 vec = new Vector3(rigid.velocity.x, rigid.velocity.y, 0f);

        

    }


}
