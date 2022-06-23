using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingSphere : MonoBehaviour
{
    private Rigidbody rd;
    public Transform main_form;
    public Transform playertransform;
    public Transform jiao;
    public LayerMask ground;
    [SerializeField,Range(0f,300f)]
    float speed;
    [SerializeField, Range(0f, 100f)]
    float js;
    public int maxjump;
    private Vector3 offset;
    int jump ;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        jump = maxjump;
        //Debug.Log("game started");
        rd = GetComponent<Rigidbody>();
        offset = main_form.position - playertransform.position;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGround = Physics2D.OverlapCircle(jiao.position, 0.1f, ground);
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W ))&& jump>0)
        {
            rd.AddForce(new Vector3(0, 600, 0));
            jump--;
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
        main_form.position = playertransform.position + offset;
        
    }
    void OnTriggerEnter(Collider other)
    {
        jump = maxjump;
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rd.AddForce(new Vector3(speed * h, 0, 0));

        if (!(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            rd.AddForce(new Vector3(-rd.velocity.x * js, 0, 0));

        }

        if (rd.velocity.x > 9)

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
