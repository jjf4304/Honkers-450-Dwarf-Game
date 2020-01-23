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
    const float rotationAmount = .1f;
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
        cam.transform.position = new Vector3(0, transform.position.y - offset, -10f);
        sideSpeed = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            sideSpeed = -5f;
            rotateShipBy = -rotationAmount;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sideSpeed = 5f;
            rotateShipBy = rotationAmount;
        }

        transform.Rotate(new Vector3(0f, 0f, rotateShipBy));
        rotateShipBy = 0;

        rigid.velocity = new Vector2(sideSpeed, downSpeed);
        Vector3 vec = new Vector3(rigid.velocity.x, rigid.velocity.y, 0f);

        



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Left Wall"))
        {
            
        }

        if (collision.gameObject.tag.Equals("Right Wall"))
        {

        }
    }

}
