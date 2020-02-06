using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    	// initialize a component of game object, type is Rigitbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // add a force vector to a Rigidbody
        rb.AddForce(movement * speed);
    }

    // default function to detect object collisions
    void OnTriggerEnter(Collider other) {
        // check if object entering is 'pick up'
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // set object as invisible once collide
            other.gameObject.SetActive(false);
        }
    }
}
