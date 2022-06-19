using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingSphere : MonoBehaviour
{
    private Rigidbody rd;
    public Transform main_form;
    public Transform playertransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("game started");
        rd = GetComponent<Rigidbody>();
        offset = main_form.position - playertransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h=Input.GetAxis("Horizontal");
        rd.AddForce(new Vector3(5*h, 0, 0));
        transform.eulerAngles = new Vector3(0, 0, 0);
        main_form.position = playertransform.position + offset;
        if ((!Input.GetKeyDown("d"))&& (!Input.GetKeyDown("a")))
        {
            rd.AddForce(new Vector3(-rd.velocity.x, 0, 0));

        }
        if (Input.GetKeyDown("w")) 
        {
            rd.AddForce(new Vector3(0, 600, 0));

        
        }
        if (rd.velocity.x>9)
        {
            rd.AddForce(new Vector3(-5 * h, 0, 0));

        }
        if (rd.velocity.x < -9)
        {
            rd.AddForce(new Vector3(-5 * h, 0, 0));
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
