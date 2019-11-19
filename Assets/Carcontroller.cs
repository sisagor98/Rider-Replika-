using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    bool move = false;
    bool isGrounded= false;
    public float rotationSpeed = 2f;

    public float speed = 500f;
    public Rigidbody2D rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1")){
            move = true;
        }
        if(Input.GetButtonUp("Fire1")){
            move = false;
        }
    }

    private void FixedUpdate() {
        if(move == true) 
        {
            if (isGrounded){
                rigidbody.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else{
                rigidbody.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }

        }   
    }

    private void OnCollisionEnter2D()
	{
		isGrounded = true;
	}

	private void OnCollisionExit2D()
	{
		isGrounded = false;
	}



}
