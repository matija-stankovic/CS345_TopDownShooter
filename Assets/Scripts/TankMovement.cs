using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float speed = 5;
    public float turnSpeed = 5;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        TankControls();
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0)
        {
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
            transform.Rotate(new Vector3(0, 0, h * turnSpeed * Time.deltaTime));
            //= Quaternion.Euler(0, 0, -90 * h * turnSpeed);
        }
        else if(v != 0)
        {
            transform.position += new Vector3(0, v * speed * Time.deltaTime, 0);
            transform.Rotate(new Vector3(0, 0, v * turnSpeed * Time.deltaTime));
            //transform.rotation = Quaternion.Euler(0, 0, (90 - 90 * v) * turnSpeed);
        }
    }

    void TankControls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0)); //+= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0)); //-= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, turnSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime));
        }
    }

}
