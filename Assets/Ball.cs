using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float moveSpeed = 10f;
    private Rigidbody rb;
    private Renderer rend;
    private Light light;
    float moveX, moveZ;
    public Vector3 velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        light = GetComponent<Light>();
        moveX = moveSpeed; //inputX * moveSpeed * Time.deltaTime;
        moveZ = moveSpeed;//inputZ * moveSpeed * Time.deltaTime;
        velocity = rb.velocity;
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");



        rb.AddForce(moveX, 0f, moveZ);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Wall1")
        {
            rend.material.color = Color.blue;
            light.color = Color.blue;
            rb.velocity = new Vector3(0, 0, -moveSpeed);
            moveZ = -moveSpeed;
        }
        else if (col.collider.name == "Wall2")
        {
            rend.material.color = Color.green;
            light.color = Color.green;
            rb.velocity = new Vector3(0, 0, moveSpeed);
            moveZ = moveSpeed;
        }
        else if (col.collider.name == "Wall3")
        {
            rend.material.color = Color.yellow;
            light.color = Color.yellow;
            rb.velocity = new Vector3(moveSpeed, 0, 0);
            moveX = moveSpeed;
        }
        else if (col.collider.name == "Wall4")
        {
            rend.material.color = Color.red;
            light.color = Color.red;
            rb.velocity = new Vector3(-moveSpeed,0,0);
            moveX = -moveSpeed;
        }
    }
}
