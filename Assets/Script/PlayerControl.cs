using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // add a force vector to a Rigidbody
        // rb.AddForce(movement * speed);
        rb.velocity = new Vector3(moveHorizontal*speed, 0.0f, moveVertical*speed);
    }

    // default function to detect object collisions
    void OnTriggerEnter(Collider other) {
        // check if object entering is 'pick up'
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // set object as invisible once collide
            other.gameObject.SetActive(false);

            // increase ball size after collecting each pickup
            rb.transform.localScale += new Vector3(0.3f,0.3f,0.3f);
        }

        if (other.gameObject.CompareTag("FinalPickup")) {
             SceneManager.LoadScene("Game Over");
        }
    }
}
