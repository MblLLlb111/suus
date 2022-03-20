using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float Speed = 0;
    public float RotationSpeed = 0;
    private Rigidbody _rigidbody;
    public float MaxSpeed = 20;
    public float MaxSpeedBack = -5;
    public float MaxRotationSpeed = 7;
    public bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void OnCollisionStay(Collision collision)
    {
        GameObject Plane = collision.gameObject;

           if (Plane.layer==3) isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.layer == 3) isGrounded = false;
  
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (isGrounded)
        {
            
            if (RotationSpeed <= MaxRotationSpeed)
            {
                RotationSpeed = Speed * 0.3f;
            }


            if (Speed <= MaxSpeed)
            {
                if (Input.GetKey("w"))
                {
                    Speed = Speed + 0.1f;
                }


            }

            if (Speed >= MaxSpeedBack)
            {
                if (Input.GetKey("s"))
                {
                    Speed = Speed - 0.1f;
                }

            }


            float forwardForce = Input.GetAxis("Vertical") * Speed;
            float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
            _rigidbody.AddRelativeForce(0, 0, forwardForce);
            _rigidbody.AddRelativeTorque(0, sideForce, 0);
        }

        
    }
}
